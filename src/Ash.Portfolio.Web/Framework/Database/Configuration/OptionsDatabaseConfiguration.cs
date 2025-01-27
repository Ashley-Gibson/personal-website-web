using Ash.Portfolio.Web.Framework.Database.Options;
using Microsoft.Extensions.Options;

namespace Ash.Portfolio.Web.Framework.Database.Configuration;

public class OptionsDatabaseConfiguration : IConfiguration
{
    private readonly IOptions<DatabaseOptions> _databaseClientOptions;

    public OptionsDatabaseConfiguration(IOptions<DatabaseOptions> databaseClientOptions)
    {
        _databaseClientOptions = databaseClientOptions;
    }
    public Configuration GetConfiguration()
    {
        return new Configuration(_databaseClientOptions.Value.ServerName,
            _databaseClientOptions.Value.DatabaseName);
    }
}
