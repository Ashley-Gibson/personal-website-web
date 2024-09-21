using Microsoft.AspNetCore.Components;

namespace Ash.Portfolio.Web.Components.Pages;

public class PageBase : ComponentBase
{
    [Inject]
    public NavigationManager? NavigationManager { get; set; }

    public void NavigateToInterestsPage()
    {
        NavigationManager?.NavigateTo("/interests", true);
    }
}
