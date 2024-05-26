using Microsoft.AspNetCore.Components;
using WebApp.Application.Common.Constants;
using WebApp.Components.Layout;

namespace WebApp.Components.Pages.Identity;

[Layout(typeof(BasicLayout))]
[Route(RouteConst.Identity.UnAuthorised)]
public partial class UnAuthorisedPage
{
}
