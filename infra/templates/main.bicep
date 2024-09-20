param location string = resourceGroup().location
param resource_name_post_fix string
param web_app_service_name string
param web_app_service_plan_sku string
param web_app_service_plan_tier string

param acr_resource_group_name string
param acr_name string
param deploymentGuidValue string = newGuid()

param key_vault_name string

var tags = {
  System: resourceGroup().tags.SystemTag
}

module webAppServicePlan 'modules/appserviceplan.bicep' = {
  name: 'plan_web_deployment_${deploymentGuidValue}'
  params: {
    name: 'plan-${resource_name_post_fix}-personal-website-web'
    location: location
    tags: tags
    sku: {
      name: web_app_service_plan_sku
      tier: web_app_service_plan_tier
    }
  }
}

module webAppServiceUid 'modules/user-managed-identity.bicep' = {
  name: 'web-user-identity'
  scope: resourceGroup()
  params: {
    resourceName: web_app_service_name
    location: location
  }
}

module webAppService 'modules/appservice.bicep' = {
  name: 'webAppDeployment'
  params: {
    name: web_app_service_name
    location: location
    tags: tags
    web_app_service_plan_id: webAppServicePlan.outputs.appServicePlanId
    user_managed_identity_name: webAppServiceUid.outputs.name  
    managed_identity_type: 'SystemAssigned' 
  }
  dependsOn: [
    webAppServicePlan
  ]
}

module webAppServiceContainerRegistryManagedIdentity 'modules/containerregistry-roleassignment.bicep' = {
  name: 'app_web_cr_id_deployment_${deploymentGuidValue}'
  params: {
    acr_name: acr_name
    principal_id: webAppService.outputs.appServiceIdentityId
  }
  dependsOn: [
    webAppService
  ]
  scope: resourceGroup(acr_resource_group_name)
}

module webAppKeyVaultManagedIdentity 'modules/keyvault-roleassignment.bicep' = {
  name: 'web_kv_id_deployment_${deploymentGuidValue}'
  params: {
    key_vault_name: key_vault_name
    principal_id: webAppService.outputs.appServiceIdentityId
  }
  dependsOn: [
    webAppService
  ]
}
