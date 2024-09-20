param acr_name string
param principal_id string

var acr_pull_role_id = ''

resource containerRegistry 'Microsoft.ContainerRegistry/registries@2021-09-01' existing = {
  name: acr_name
}

resource acrPullRoleDefinition 'Microsoft.Authorization/roleDefinitions@2018-01-01-preview' existing = {
  name: acr_pull_role_id
}

resource acr_servicePrincipalRole 'Microsoft.Authorization/roleAssignments@2020-08-01-preview' = {
  scope: containerRegistry
  name: guid(containerRegistry.id, principal_id, acrPullRoleDefinition.id)
  properties: {
    principalId: principal_id
    principalType: 'ServicePrincipal'
    roleDefinitionId: acrPullRoleDefinition.id
  }
}
