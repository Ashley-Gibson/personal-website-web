using Microsoft.AspNetCore.Components;

namespace Ash.Portfolio.Web.Components.Pages;

public class PageBase : ComponentBase
{
    [Inject]
    protected NavigationManager? NavigationManager { get; set; }

    protected void NavigateToInterestsPage()
    {
        NavigationManager?.NavigateTo("/interests", true);
    }
}
