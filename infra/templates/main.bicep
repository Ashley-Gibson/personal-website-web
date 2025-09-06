param resource_name_post_fix string
param web_app_service_name string
param web_app_service_plan_sku string
param web_app_service_plan_tier string
param deploymentGuidValue string = newGuid()

param system_tag string

var tags = {
  System: system_tag
}

module webAppServicePlan 'modules/appserviceplan.bicep' = {
  name: 'plan_webappservice_deployment_${deploymentGuidValue}'
  params: {
    name: 'plan-${resource_name_post_fix}-personal-website-web'
    location: resourceGroup().location
    tags: tags
    sku: {
      name: web_app_service_plan_sku
      tier: web_app_service_plan_tier
    }
  }
}

module webAppService 'modules/appservice.bicep' = {
  name: 'webAppService_deployment_${deploymentGuidValue}'
  params: {
    name: web_app_service_name
    location: resourceGroup().location
    tags: tags
    web_app_service_plan_id: webAppServicePlan.outputs.appServicePlanId
  }
}
