param (
    [string] $location = "northeurope",
    [parameter(Mandatory)] [string] $subscriptionId,
    [parameter(Mandatory)] [string] $resourceGroupName,
    [parameter(Mandatory)] [ValidateSet("prod")] [string] $env
)

Write-Host "Starting Deployment..."
Get-Date

# 1. login to Azure
Write-Host "Logging in to Azure..."
#az login

# 2. set the default subscription
Write-Host "Setting default subscription Id..."
az account set -s $subscriptionId

# 3. deploy all the resources to the resource group
Write-Host "Deploying Azure resources..."
az deployment group create --resource-group $resourceGroupName --template-file templates/main.bicep --parameters templates/azure-deploy.parameters.$env.json

Write-Host "Completed Deployment."
Get-Date
