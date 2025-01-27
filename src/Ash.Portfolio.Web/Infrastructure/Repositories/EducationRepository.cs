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

    private async Task<IEnumerable<Institute>> GetInstitutesAsync()
    {
        var p = new DynamicParameters();

        return await _database.QueryAsync<Institute>("[Education].[uspGetInstitutes]", p);
    }

    public async Task<IEnumerable<InstituteDescription>> GetInstituteDescriptionsAsync()
    {
        var p = new DynamicParameters();

        return await _database.QueryAsync<InstituteDescription>("[Education].[uspGetInstituteDescriptions]", p);
    }

    public async Task<IEnumerable<Institute>> GetInstitutesWithDescriptionAsync()
    {
        var institutes = await GetInstitutesAsync();
        var institutesDescriptions = await GetInstituteDescriptionsAsync();

        institutes
            .ToList()
            .ForEach(d =>
            {
                d.DescriptionRows = institutesDescriptions.Where(r => r.ParentId == d.Id).ToList();
            });

        return institutes;
    }
}
