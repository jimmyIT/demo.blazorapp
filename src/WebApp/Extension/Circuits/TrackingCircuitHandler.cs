using FluentResults;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using WebApp.Application.Common.Constants;
using WebApp.Application.Common.Services.AuthenState;

namespace WebApp.Extension.Circuits;

public class TrackingCircuitHandler : CircuitHandler
{
    private readonly ProtectedLocalStorage _protectedLocalStorage;
    private readonly IAuthenticationService _authenticationSvc;
    private readonly IUserStateActionService _authenticatedUserSvc;
    public TrackingCircuitHandler(
        ProtectedLocalStorage protectedLocalStorage,
        IAuthenticationService authenticationService,
        IUserStateActionService authenticatedUserSvc)
    {
        _protectedLocalStorage = protectedLocalStorage;
        _authenticationSvc = authenticationService;
        _authenticatedUserSvc = authenticatedUserSvc;
    }

    public override async Task OnCircuitOpenedAsync(
        Circuit circuit,
        CancellationToken cancellationToken)
    {
        await base.OnCircuitOpenedAsync(circuit, cancellationToken);
    }

    public override async Task OnConnectionUpAsync(
        Circuit circuit,
        CancellationToken cancellationToken)
    {
        ProtectedBrowserStorageResult<string> claimsPrincipalResult =
            await _protectedLocalStorage.GetAsync<string>(LocalStorageKeyConst.UserDetails);

        if (claimsPrincipalResult is { Success: true, Value: not null })
        {
            // TODO
            await _authenticatedUserSvc.SignInAsync();
        }

        await base.OnConnectionUpAsync(circuit, cancellationToken);
    }

    public override Task OnConnectionDownAsync(
        Circuit circuit,
        CancellationToken cancellationToken)
    {
        return base.OnConnectionDownAsync(circuit, cancellationToken);
    }

    public override Task OnCircuitClosedAsync(
        Circuit circuit,
        CancellationToken cancellationToken)
    {
        return base.OnCircuitClosedAsync(circuit, cancellationToken);
    }
}
