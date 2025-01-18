using Ash.Portfolio.Web.Infrastructure.Repositories;

namespace Ash.Portfolio.Web.Framework.ServiceCollectionExtensions;

public static class RepositoryServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IEducationRepository, EducationRepository>();
        services.AddTransient<IExperienceRepository, ExperienceRepository>();
        services.AddTransient<IPortfolioRepository, PortfolioRepository>();

        return services;
    }
}
