using Ash.Portfolio.Web.Framework.Database;
using Ash.Portfolio.Web.Framework.Database.Constants;
using Ash.Portfolio.Web.Framework.Database.Factory;
using Dapper;

namespace Ash.Portfolio.Web.Infrastructure.Repositories;

public class InterestsRepository : IInterestsRepository
{
    private readonly IDatabase _database;

    public InterestsRepository(IDatabaseFactory databaseFactory)
    {
        _database = databaseFactory.GetDatabase(DatabaseName.Ash_Portfolio_Database);
    }

    public async Task<IEnumerable<string>> GetPhotoGalleryImageLinksAsync()
    {
        var p = new DynamicParameters();

        return await _database.QueryAsync<string>("[Interests].[uspGetPhotoGalleryImageLinks]", p);
    }
}
