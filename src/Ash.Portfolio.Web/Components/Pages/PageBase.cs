using Microsoft.AspNetCore.Components;

namespace Ash.Portfolio.Web.Components.Pages;

public class PageBase : ComponentBase
{
    [Inject]
    internal NavigationManager NavigationManager { get; set; } = default!;

    internal void NavigateToInterestsPage()
    {
        NavigationManager?.NavigateTo("/interests", true);
    }
}
