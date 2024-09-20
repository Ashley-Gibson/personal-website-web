param name string
param location string = resourceGroup().location
param tags object
param sku object

resource appServicePlan 'Microsoft.Web/serverfarms@2021-03-01' = {
  name: name
  location: location
  tags: tags
  kind: 'linux'
  sku: sku
  properties: {
    reserved: true
  }
}

output appServicePlanId string = appServicePlan.id
