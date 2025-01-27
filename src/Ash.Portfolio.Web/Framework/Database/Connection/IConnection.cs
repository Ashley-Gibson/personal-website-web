using Microsoft.Data.SqlClient;

namespace Ash.Portfolio.Web.Framework.Database.Connection;

public interface IConnection
{
    SqlConnection CreateConnection();
}
