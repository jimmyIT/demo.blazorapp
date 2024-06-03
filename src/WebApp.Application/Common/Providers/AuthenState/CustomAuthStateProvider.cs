using Microsoft.AspNetCore.Components.Authorization;
using WebApp.Application.Common.Services.AuthenState;

namespace WebApp.Application.Common.Providers.AuthenState;

/// <summary>
/// In spite of the word "state" in the name, AuthenticationStateProvider isn't for storing general user state.
/// AuthenticationStateProvider only indicates the user's authentication state to the app, whether they are signed into the app and who they are signed in as.
/// </summary>
public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private AuthenticationState _authenticationState;
    public CustomAuthStateProvider(IAuthenticationService authenticationService)
    {
        _authenticationState = new AuthenticationState(authenticationService.CurrentUser);

        authenticationService.UserChanged += (newUser) =>
        {
            _authenticationState = new AuthenticationState(newUser);

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(newUser)));
        };
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
        => Task.FromResult(_authenticationState);

    public void NotifyAuthenticationStateChanged()
        => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
}
