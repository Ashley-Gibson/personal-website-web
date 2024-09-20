param name string
param location string = resourceGroup().location
param tags object
param app_service_plan_id string
param application_insights_name string
param application_insights_resource_group_name string
param virtual_network_name string
param subnet_name string
@description('User managed identity to be assigned to this resource.')
param user_managed_identity_name string
@description('The type of managed Identity assigned to the AppService.')
@allowed([
  'SystemAssigned, UserAssigned'
  'SystemAssigned'
  'UserAssigned'
])
param managed_identity_type string 
@description('Client Id of the App Registration used for token access to Identity API.')
param identity_app_registration_client_id string

resource appInsights 'Microsoft.Insights/components@2020-02-02-preview' existing = {
  name: application_insights_name
  scope: resourceGroup(application_insights_resource_group_name)
}

resource vnet 'Microsoft.Network/virtualNetworks@2021-08-01' existing = {
  name: virtual_network_name
}

resource subnet 'Microsoft.Network/virtualNetworks/subnets@2021-08-01' existing = {
  name: subnet_name
  parent: vnet
}

resource uid 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' existing = {
  name: user_managed_identity_name
}

resource appService 'Microsoft.Web/sites@2021-03-01' = {
  name: name
  location: location
  kind: 'app,linux,container'
  tags: tags
  properties: {
    serverFarmId: app_service_plan_id
    siteConfig: {
      acrUseManagedIdentityCreds: true
      alwaysOn: true
      http20Enabled: true
      minTlsVersion: '1.2'
      ftpsState: 'Disabled'
      vnetRouteAllEnabled: true
      appSettings: [
        {
          name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
          value: appInsights.properties.ConnectionString
        } 
        {
          name: 'ManagedIdentityAuthOptions__UserManagedIdentityClientId'
          value: uid.properties.clientId
        } 
        {
          name: 'ManagedIdentityAuthOptions__AuthorisationScope'
          value: 'api://${identity_app_registration_client_id}/.default'
        }      
      ]
    }
    httpsOnly: true
    clientAffinityEnabled: true
    virtualNetworkSubnetId: subnet.id    
  }
  identity: {
    type: managed_identity_type
    userAssignedIdentities: (contains(managed_identity_type, 'UserAssigned') ? {
      '${uid.id}': {}
    } : null)
  }
}

output appServiceIdentityId string = appService.identity.principalId
