param static_web_app_name string
param static_web_app_sku string
param static_web_app_tier string
param azureRegionShort string
param sqlConnectionType string

param deploymentGuidValue string = newGuid()

var tags = resourceGroup().tags
var location = azureRegionShort

module staticWebApp 'modules/static-web-app.bicep' = {
  name: 'statWebAppDep-${deploymentGuidValue}'
  params: {
    static_web_app_name: static_web_app_name
    static_web_app_sku: static_web_app_sku
    static_web_app_tier: static_web_app_tier
    location: location
    tags: tags
  }
}