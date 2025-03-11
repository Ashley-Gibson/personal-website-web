param static_web_app_name string
param static_web_app_sku string
param static_web_app_tier string
param location string
param tags object
param publicNetworkAccess string = ''
param provider string = 'None'

// Create or Update Static Web App
resource staticWebApp 'Microsoft.Web/staticSites@2024-04-01' = {
  name: static_web_app_name
  location: location
  tags: tags
  //identity: null
  sku: {
    name: static_web_app_sku
    tier: static_web_app_tier
  }
  properties: {
    allowConfigFileUpdates: null
    stagingEnvironmentPolicy: null
    enterpriseGradeCdnStatus: null
    provider: !empty(provider) ? provider : 'None'
    branch: null
    buildProperties: null
    repositoryToken: null
    repositoryUrl: null
    templateProperties: null
    publicNetworkAccess: !empty(publicNetworkAccess)
      ? any(publicNetworkAccess)
      : null
  }
}

output endpoint string = staticWebApp.properties.defaultHostname