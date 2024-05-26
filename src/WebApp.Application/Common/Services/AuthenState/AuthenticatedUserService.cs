using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using WebApp.Application.Common.Constants;

namespace WebApp.Application.Common.Services.AuthenState;
public interface IAuthenticatedUserService
{
    Task<bool> IsAuthenticated();
    Task SignInAsync();
    Task SignOutAsync();
}

public class AuthenticatedUserService : IAuthenticatedUserService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly IAuthenticationService _authenticationSvc;
    private readonly ProtectedLocalStorage _protectedLocalStorage;
    public AuthenticatedUserService(
        AuthenticationStateProvider authenticationStateProvider,
        IAuthenticationService authenticationService,
        ProtectedLocalStorage protectedLocalStorage)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _authenticationSvc = authenticationService;
        _protectedLocalStorage = protectedLocalStorage;
    }

    public async Task<bool> IsAuthenticated()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task SignInAsync()
    {
        // TODO
        var identity = new ClaimsIdentity(
            new[]
            {
                new Claim(ClaimTypes.Name, "Jimmy"),
            },
            "Custom Authentication");

        var newUser = new ClaimsPrincipal(identity);

        _authenticationSvc.CurrentUser = newUser;

        await _protectedLocalStorage.SetAsync(LocalStorageKeyConst.UserDetails, newUser.Identity!.Name!);
    }

    public async Task SignOutAsync()
    {
        _authenticationSvc.CurrentUser = new ClaimsPrincipal();
        await _protectedLocalStorage.DeleteAsync(LocalStorageKeyConst.UserDetails);
    }
}
