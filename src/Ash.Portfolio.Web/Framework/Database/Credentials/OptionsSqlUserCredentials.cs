using Ash.Portfolio.Web.Framework.Database.Options;
using Microsoft.Extensions.Options;

namespace Ash.Portfolio.Web.Framework.Database.Credentials;

public class OptionsSqlUserCredentials : ISqlUserCredentials
{
    private readonly IOptions<DatabaseOptions> _databaseOptions;

    public OptionsSqlUserCredentials(IOptions<DatabaseOptions> databaseOptions)
    {
        _databaseOptions = databaseOptions;
    }

    public SqlUserCredentials GetCredentials()
    {
        return new SqlUserCredentials() { UserId = _databaseOptions.Value.SqlUserCredentials?.UserId!, Password = _databaseOptions.Value.SqlUserCredentials?.Password! };
    }
}
