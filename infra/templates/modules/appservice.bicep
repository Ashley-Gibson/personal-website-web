param name string
param location string = resourceGroup().location
param tags object
param web_app_service_plan_id string
@description('User managed identity to be assigned to this resource.')
param user_managed_identity_name string
@description('The type of managed Identity assigned to the AppService.')
@allowed([
  'SystemAssigned, UserAssigned'
  'SystemAssigned'
  'UserAssigned'
])
param managed_identity_type string 

resource uid 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' existing = {
  name: user_managed_identity_name
}

resource appService 'Microsoft.Web/sites@2021-03-01' = {
  name: name
  location: location
  kind: 'app,linux,container'
  tags: tags
  properties: {
    serverFarmId: web_app_service_plan_id
    siteConfig: {
      acrUseManagedIdentityCreds: true
      alwaysOn: true
      http20Enabled: true
      minTlsVersion: '1.2'
      ftpsState: 'Disabled'
      appSettings: []
    }
    httpsOnly: true
    clientAffinityEnabled: true
  }
  identity: {
    type: managed_identity_type
    userAssignedIdentities: (contains(managed_identity_type, 'UserAssigned') ? {
      '${uid.id}': {}
    } : null)
  }
}

output appServiceIdentityId string = appService.identity.principalId
