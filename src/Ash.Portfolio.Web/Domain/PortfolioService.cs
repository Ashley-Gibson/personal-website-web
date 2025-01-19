using Ash.Portfolio.Web.Infrastructure.Data.Portfolio;
using Ash.Portfolio.Web.Infrastructure.Repositories;

namespace Ash.Portfolio.Web.Domain;

public class PortfolioService : IPortfolioService
{
    private readonly IPortfolioRepository _portfolioRepository;

    public PortfolioService(IPortfolioRepository portfolioRepository)
    {
        _portfolioRepository = portfolioRepository;
    }

    public IEnumerable<Project> FilterProjectsByType(IEnumerable<Project> projects, ProjectType projectType)
    {
        if (projects is null)
            return [];

        return projects.Where(p => p.Status == projectType.ToString());
    }
}
