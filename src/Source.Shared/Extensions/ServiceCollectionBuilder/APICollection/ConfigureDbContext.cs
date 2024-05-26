using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Source.EF.Contexts;

namespace Source.Shared.Extensions.ServiceCollectionBuilder.APICollection;

public static class ConfigureDbContext
{
    public static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseLazyLoadingProxies()
                   .UseSqlServer(configuration[$"ConnectionStrings:DefaultConnection"]);
        });
    }
}
