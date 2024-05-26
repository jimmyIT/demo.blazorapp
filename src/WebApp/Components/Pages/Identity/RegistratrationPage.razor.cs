using Microsoft.AspNetCore.Components;
using MudBlazor;
using WebApp.Application.Common.Constants;
using WebApp.Application.Models.IdentityPages.Register;
using WebApp.Components.Layout;

namespace WebApp.Components.Pages.Identity;

[Layout(typeof(BasicLayout))]
[Route(RouteConst.Identity.Register)]
public partial class RegistratrationPage
{
    private MudForm _form = default!;
    private RegistrationDetailsModel _registrationDetailsModel = new();
    private RegistrationDetailsValidator _registrationModelValidator = new();

    private InputType _passwordInputType = InputType.Password;
    private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
    private bool _isShowPassword;

    private Task PasswordEye_click()
    {
        if (_isShowPassword)
        {
            _isShowPassword = false;
            _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
            _passwordInputType = InputType.Password;
        }
        else
        {
            _isShowPassword = true;
            _passwordInputIcon = Icons.Material.Filled.Visibility;
            _passwordInputType = InputType.Text;
        }

        return Task.CompletedTask;
    }
}
