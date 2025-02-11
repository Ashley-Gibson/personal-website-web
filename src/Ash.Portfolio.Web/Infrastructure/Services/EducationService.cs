using Ash.Portfolio.Web.Infrastructure.Data.Education;
using Ash.Portfolio.Web.Infrastructure.Repositories;

namespace Ash.Portfolio.Web.Infrastructure.Services;

public class EducationService(IEducationRepository educationRepository) : IEducationService
{
    public async Task<IEnumerable<Institute>> GetInstitutesWithDescriptionAsync()
    {
        var institutes = await educationRepository.GetInstitutesAsync();
        var institutesDescriptions = await educationRepository.GetInstituteDescriptionsAsync();

        institutes
            .ToList()
            .ForEach(d =>
            {
                d.DescriptionRows = institutesDescriptions.Where(r => r.ParentId == d.Id).ToList();
            });

        return institutes;
    }
}
