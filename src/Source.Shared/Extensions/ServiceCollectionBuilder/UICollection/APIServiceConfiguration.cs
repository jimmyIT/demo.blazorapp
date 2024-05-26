using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Source.Shared.Models;

namespace Source.Shared.Extensions.ServiceCollectionBuilder.UICollection;

public static class APIServiceConfiguration
{
    public static void AddAPIServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        WebApiSettings? apiConfigs =
            configuration.GetSection(APIConfiguration.SettingKey)
                         .Get<WebApiSettings>();

        if (apiConfigs == null)
        {
            throw new ArgumentNullException(nameof(WebApiSettings));
        }

        services.AddSingleton(apiConfigs);

        services.Configure<WebApiSettings>(configuration.GetSection(APIConfiguration.SettingKey));

        services.AddSingleton(sp => new FlurlClientCache().Add(apiConfigs.ApiName, apiConfigs.ApiUrl));
    }
}
