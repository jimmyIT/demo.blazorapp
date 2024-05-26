using MudBlazor.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApp.Application.Common.Extensions.ServiceCollection;
using WebApp.Components;
using WebApp.Extension.Circuits;
using WebApp.Extension.Handlers;
using Source.Shared.Extensions.ServiceCollectionBuilder.UICollection;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScopedProcessors();
builder.Host.AddAutofacConfiguration();
builder.Services.AddAuthenStateConfig();
builder.Services.AddAPIServiceConfiguration(configuration);
builder.Services.AddMudServices();
builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, BlazorAuthorizationMiddlewareResultHandler>();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthentication();
builder.Services.AddAuthorizationCore();
builder.Services.TryAddEnumerable(ServiceDescriptor.Scoped<CircuitHandler, TrackingCircuitHandler>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
