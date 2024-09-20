param key_vault_name string
param principal_id string

var key_vault_secrets_user_role_id = ''

resource keyVault 'Microsoft.KeyVault/vaults@2021-11-01-preview' existing = {
  name: key_vault_name
}

resource keyVaultSecretsUserRoleDefinition 'Microsoft.Authorization/roleDefinitions@2018-01-01-preview' existing = {
  name: key_vault_secrets_user_role_id
}

resource keyVaultFunctionAppPermissions 'Microsoft.Authorization/roleAssignments@2020-04-01-preview' = {
  name: guid(keyVault.id, principal_id, keyVaultSecretsUserRoleDefinition.id)
  scope: keyVault
  properties: {
    principalId: principal_id
    principalType: 'ServicePrincipal'
    roleDefinitionId: keyVaultSecretsUserRoleDefinition.id
  }
}
