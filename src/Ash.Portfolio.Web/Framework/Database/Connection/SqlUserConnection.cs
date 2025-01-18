using Ash.Portfolio.Web.Framework.Database.Credentials;
using Microsoft.Data.SqlClient;

namespace Ash.Portfolio.Web.Framework.Database.Connection;

public class SqlUserConnection : IConnection
{
    private readonly Configuration.IConfiguration _configuration;
    private readonly ISqlUserCredentials _databaseSqlUserCredentials;
    private readonly ISqlUserConnectionStringBuilder _databaseConnectionStringBuilder;

    public SqlUserConnection(Configuration.IConfiguration configuration, ISqlUserCredentials sqlUserCredentials, ISqlUserConnectionStringBuilder connectionStringBuilder)
    {
        _configuration = configuration;
        _databaseSqlUserCredentials = sqlUserCredentials;
        _databaseConnectionStringBuilder = connectionStringBuilder;
    }

    public SqlConnection CreateConnection()
    {
        var databaseConfiguration = _configuration.GetConfiguration();
        var databaseCredentials = _databaseSqlUserCredentials.GetCredentials();

        var connectionString = _databaseConnectionStringBuilder.BuildConnectionString(databaseConfiguration.Server, databaseConfiguration.Database, databaseCredentials.UserId, databaseCredentials.Password);
        return new SqlConnection(connectionString);
    }
}
