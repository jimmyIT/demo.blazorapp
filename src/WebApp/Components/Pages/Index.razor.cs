using Microsoft.AspNetCore.Components;
using WebApp.Application.Common.Constants;
using WebApp.Application.Common.Services.AuthenState;
using WebApp.Components.Layout;

namespace WebApp.Components.Pages;

[Layout(typeof(BasicLayout))]
[Route(RouteConst.Default)]
public partial class Index
{
    [Inject] IAuthenticatedUserService _authenticatedUserSvc { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        bool isAuthen = await _authenticatedUserSvc.IsAuthenticated();
        if (isAuthen)
        {
            _navigateManager.NavigateTo(RouteConst.Dashboard.User);
        }
        else
        {
            _navigateManager.NavigateTo(RouteConst.Identity.SignIn);
        }
    }
}
