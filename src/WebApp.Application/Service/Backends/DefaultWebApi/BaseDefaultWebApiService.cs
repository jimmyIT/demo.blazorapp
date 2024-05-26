using Flurl.Http.Configuration;
using Microsoft.Extensions.Options;
using Source.Shared.Common.FlurlAPIConfiguration;
using Source.Shared.Models;
using WebApp.Application.Service.Interfaces;

namespace WebApp.Application.Service.Backends.DefaultWebApi;

public class BaseDefaultWebApiService(
        IOptions<WebApiSettings> apiConfigurationOption,
        IFlurlClientCache flurlClientCache)
    : FlurlAPIBaseService(apiConfigurationOption, flurlClientCache), IBaseDefaultWebApiService
{
}
