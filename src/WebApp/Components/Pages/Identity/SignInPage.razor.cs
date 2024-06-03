using FluentResults;
using Mapster;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using WebApp.Application.Common.Constants;
using WebApp.Application.Common.Services.AuthenState;
using WebApp.Application.Models.IdentityPages.Signin;
using WebApp.Application.Processors.Identity.SignIn;
using WebApp.Components.Layout;

namespace WebApp.Components.Pages.Identity;

[Layout(typeof(BasicLayout))]
[Route(RouteConst.Identity.SignIn)]
public partial class SignInPage
{
    [Inject] ISignInProcessor _signinProcessor { get; set; } = default!;
    [Inject] IUserStateActionService _authenticatedUserSvc { get; set; } = default!;

    private MudForm _form = default!;
    private SignInModelValidator _signinModelValidator = new();
    private SignInModel _signInModel = new();

    private bool _isShowPassword;
    private InputType _passwordInputType = InputType.Password;
    private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

    private async Task SignIn()
    {
        await _form.Validate();
        if (_form.IsValid == false)
        {
            return;
        }

        SignInProcessorModel signInProcessorModel = _signInModel.Adapt<SignInProcessorModel>();
        Result<SignInProcessorResult> signInActionResult = await _signinProcessor.DoActionAsync(signInProcessorModel);
        
        if (signInActionResult.IsFailed)
        {
            await _dialogService.ShowMessageBox(
                "Error",
                "Wrong password!!!",
                cancelText: "Try again");
            return;
        }

        await _authenticatedUserSvc.SignInAsync();

        _navigateManager.NavigateTo(RouteConst.Default);
    }

    private Task PasswordEye_click()
    {
        if(_isShowPassword)
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
