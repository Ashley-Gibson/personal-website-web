param resourceName string
param location string = resourceGroup().location

resource ui 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: 'id-${resourceName}'
  location: location
  tags: resourceGroup().tags
}

output name string = ui.name
output principalId string = ui.properties.principalId
output clientId string = ui.properties.clientId
