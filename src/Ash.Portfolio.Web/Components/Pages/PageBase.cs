using Microsoft.AspNetCore.Components;

namespace Ash.Portfolio.Web.Components.Pages;

public class PageBase : ComponentBase
{
    [Inject]
    internal NavigationManager NavigationManager { get; set; } = default!;

    internal const string InterestsPageName = "interests";


    internal void NavigateToPage(string pageName)
    {
        NavigationManager?.NavigateTo($"/{pageName}", true);
    }
}
