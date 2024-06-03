using Autofac;
using Autofac.Util;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using WebApp.Application.Common.Providers.AuthenState;
using WebApp.Application.Common.Services.AuthenState;

namespace WebApp.Application.Common.Extensions.ServiceCollection;

public static class AuthenStateConfiguration
{
    /// <summary>
    /// AddCascadingAuthenticationState.
    /// AddScoped<AuthenticationService>().
    /// </summary>
    /// <param name="services"></param>
    public static void AddAuthenStateConfig(this IServiceCollection services)
    {
        services.AddCascadingAuthenticationState();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserStateActionService, UserStateActionService>();
        services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
    }
}
