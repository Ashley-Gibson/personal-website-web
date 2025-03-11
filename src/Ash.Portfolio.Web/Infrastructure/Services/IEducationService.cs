using Ash.Portfolio.Web.Infrastructure.Data.Education;

namespace Ash.Portfolio.Web.Infrastructure.Services;

public interface IEducationService
{
    Task<IEnumerable<Institute>> GetInstitutesWithDescriptionAsync();
}
