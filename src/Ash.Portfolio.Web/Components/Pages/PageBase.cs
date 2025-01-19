using Ash.Portfolio.Web.Domain;
using Ash.Portfolio.Web.Infrastructure.Repositories;
using Microsoft.AspNetCore.Components;

namespace Ash.Portfolio.Web.Components.Pages;

public class PageBase : ComponentBase
{
    [Inject]
    internal NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    internal IPortfolioRepository PortfolioRepository { get; set; } = default!;

    [Inject]
    internal IPortfolioService PortfolioService { get; set; } = default!;

    internal void NavigateToInterestsPage()
    {
        NavigationManager?.NavigateTo("/interests", true);
    }

    internal List<Infrastructure.Data.Portfolio.Project> CompleteProjectData { get; set; } = [];

    internal List<Infrastructure.Data.Portfolio.Project> InProgressProjectData { get; set; } = [];

    internal List<Infrastructure.Data.Portfolio.Project> GamesProjectData { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        var projects = await PortfolioRepository.GetProjectsAsync();

        CompleteProjectData = PortfolioService.FilterProjectsByType(projects, ProjectType.Complete).ToList();
        InProgressProjectData = PortfolioService.FilterProjectsByType(projects, ProjectType.InProgress).ToList();
        GamesProjectData = PortfolioService.FilterProjectsByType(projects, ProjectType.Game).ToList();
    }
}
