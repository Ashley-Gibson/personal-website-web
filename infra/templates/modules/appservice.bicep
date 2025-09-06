param name string
param location string = resourceGroup().location
param tags object
param web_app_service_plan_id string

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
}

output appServiceIdentityId string = appService.identity.principalId
