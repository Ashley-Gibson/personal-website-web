using System.Text;

namespace Ash.Portfolio.Web.Framework.Database.Connection;

public class SqlUserConnectionStringBuilder : ISqlUserConnectionStringBuilder
{
    private readonly int _connectionTimeout;
    private readonly bool _trustServerCertificate;
    private readonly bool _multipleActiveResultSets;
    private const bool DefaultTrustServerCertificate = true;
    private const bool DefaultMultipleActiveResultSets = false;

    public SqlUserConnectionStringBuilder(
        int connectionTimeout,
        bool trustServerCertificate = DefaultTrustServerCertificate,
        bool multipleActiveResultSets = DefaultMultipleActiveResultSets)
    {
        _connectionTimeout = connectionTimeout;
        _trustServerCertificate = trustServerCertificate;
        _multipleActiveResultSets = multipleActiveResultSets;
    }

    public string BuildConnectionString(string server, string database, string userId = "", string password = "")
    {
        var connectionStringBuilder = new StringBuilder();
        connectionStringBuilder.Append($"Data Source={server};");
        connectionStringBuilder.Append($"Initial Catalog={database};");
        connectionStringBuilder.Append($"User Id={userId};");
        connectionStringBuilder.Append($"Password={password};");
        connectionStringBuilder.Append($"Connect Timeout={_connectionTimeout};");
        connectionStringBuilder.Append($"TrustServerCertificate={_trustServerCertificate};");
        connectionStringBuilder.Append($"MultipleActiveResultSets={_multipleActiveResultSets};");

        return connectionStringBuilder.ToString();
    }
}
