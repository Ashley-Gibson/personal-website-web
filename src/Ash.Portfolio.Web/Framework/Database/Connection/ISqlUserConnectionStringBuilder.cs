namespace Ash.Portfolio.Web.Framework.Database.Connection;

public interface ISqlUserConnectionStringBuilder
{
    string BuildConnectionString(string server, string database, string userId = "", string password = "");
}
