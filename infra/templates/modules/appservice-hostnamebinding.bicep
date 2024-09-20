param resource_group_name string
param app_service_name string
param dns_name string
param ssl_certificate string

resource appService 'Microsoft.Web/sites@2022-03-01' existing = {
  name: app_service_name
}

resource sslCert 'Microsoft.Web/certificates@2022-03-01' existing = {
  name: '${resource_group_name}-${ssl_certificate}'
}

resource hostnameBinding 'Microsoft.Web/sites/hostNameBindings@2022-03-01' = {
  name: dns_name
  parent: appService
  properties: {
    sslState: 'SniEnabled'
    thumbprint: sslCert.properties.thumbprint
  }
}
