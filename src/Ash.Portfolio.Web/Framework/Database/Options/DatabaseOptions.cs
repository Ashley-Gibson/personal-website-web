using Ash.Portfolio.Web.Framework.Database.Constants;
using Ash.Portfolio.Web.Framework.Database.Credentials;

namespace Ash.Portfolio.Web.Framework.Database.Options;

public class DatabaseOptions
{
    public string ConnectionTimeout { get; set; } = string.Empty;

    public string ServerName { get; set; } = string.Empty;

    public string DatabaseName { get; set; } = string.Empty;

    public SqlUserCredentials? SqlUserCredentials { get; set; }

    public AuthenticationMode AuthenticationMode { get; set; }
}
