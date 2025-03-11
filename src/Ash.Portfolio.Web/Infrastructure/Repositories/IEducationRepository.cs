using Ash.Portfolio.Web.Infrastructure.Data.Education;

namespace Ash.Portfolio.Web.Infrastructure.Repositories;

public interface IEducationRepository
{
    Task<IEnumerable<Institute>> GetInstitutesAsync();

    Task<IEnumerable<InstituteDescription>> GetInstituteDescriptionsAsync();
}
