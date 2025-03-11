using Ash.Portfolio.Web.Framework.Database;
using Ash.Portfolio.Web.Framework.Database.Constants;
using Ash.Portfolio.Web.Framework.Database.Factory;
using Ash.Portfolio.Web.Infrastructure.Data.Education;
using Dapper;

namespace Ash.Portfolio.Web.Infrastructure.Repositories;

public class EducationRepository : IEducationRepository
{
    private readonly IDatabase _database;

    public EducationRepository(IDatabaseFactory databaseFactory)
    {
        _database = databaseFactory.GetDatabase(DatabaseName.Ash_Portfolio_Database);
    }

    public async Task<IEnumerable<Institute>> GetInstitutesAsync()
    {
        var p = new DynamicParameters();

        return await _database.QueryAsync<Institute>(SQLConstants.EducationGetInstitutes, p);
    }

    public async Task<IEnumerable<InstituteDescription>> GetInstituteDescriptionsAsync()
    {
        var p = new DynamicParameters();

        return await _database.QueryAsync<InstituteDescription>(SQLConstants.EducationGetInstituteDescriptions, p);
    }
}
