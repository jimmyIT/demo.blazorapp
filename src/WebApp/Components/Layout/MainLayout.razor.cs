using Microsoft.AspNetCore.Components;
using WebApp.Application.Common.Constants;
using WebApp.Application.Common.Services.AuthenState;

namespace WebApp.Components.Layout;

public partial class MainLayout
{
    private string _unAuthorisedPage = RouteConst.Identity.UnAuthorised;

    [Inject] IAuthenticatedUserService _authenticatedUserService { get; set; } = default!; 

    bool _drawerOpen = true;

    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    private async Task SignOutOnClick()
    {
        await _authenticatedUserService.SignOutAsync();
        _navigateManager.NavigateTo(RouteConst.Default);
    }
}
