using Microsoft.AspNetCore.Components;
using WebApp.Application.Common.Constants;
using WebApp.Components.Layout;

namespace WebApp.Components.Pages.Areas.User;

[Layout(typeof(MainLayout))]
[Route(RouteConst.Dashboard.User)]
public partial class DashboardPage
{
    protected override async Task OnInitializedAsync()
    {
    }
}
