using Microsoft.AspNetCore.Mvc;
using Source.Server.WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Source.EF.Contexts;
using Source.Shared.Extensions.ServiceCollectionBuilder.APICollection;
using Source.Shared.Common.FlurlAPIConfiguration;

[assembly: ApiConventionType(typeof(ApiConventions))]

try
{
    var builder = WebApplication.CreateBuilder(args);

    IConfiguration configuration = builder.Configuration;

    builder.Services.AddControllers();
    builder.Services.AddSwaggerConfiguration();
    builder.Services.AddDbContextConfiguration(configuration);
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.ConfigureCors();
    builder.Services.ConfigureApiVersioning();
    builder.Services.AddExeptionConfiguration();
    builder.Services.ConfigureAuthentication(configuration);    
    builder.Host.AddAutofacConfiguration();
    builder.Host.RegisterSerilogConfiguration();

    var app = builder.Build();

    app.UseRouting();
    app.UseSwaggerConfiguration(app.Environment.IsDevelopment());    
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.UseCustomMiddlewaresForApi();
    app.UseAuthenticationConfiguration();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "APPLICATION FAILED TO STARTUP");
}
finally
{
    Log.CloseAndFlush();
}
