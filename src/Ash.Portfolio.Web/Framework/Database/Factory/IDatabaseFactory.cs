namespace Ash.Portfolio.Web.Framework.Database.Factory;

public interface IDatabaseFactory
{
    IDatabase GetDatabase(string database);
}
