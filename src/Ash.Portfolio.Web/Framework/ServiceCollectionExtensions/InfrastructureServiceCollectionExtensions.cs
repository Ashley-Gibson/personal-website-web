using Ash.Portfolio.Web.Infrastructure.Repositories;
using Ash.Portfolio.Web.Infrastructure.Services;

namespace Ash.Portfolio.Web.Framework.ServiceCollectionExtensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IEducationRepository, EducationRepository>();
        services.AddTransient<IExperienceRepository, ExperienceRepository>();
        services.AddTransient<IPortfolioRepository, PortfolioRepository>();
        services.AddTransient<IInterestsRepository, InterestsRepository>();

        services.AddTransient<IEducationService, EducationService>();

        return services;
    }
}
