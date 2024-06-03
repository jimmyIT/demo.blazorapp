using Microsoft.Extensions.Logging;
using Source.EF.Repositories;
using Source.Server.Application.Services.Internal.Errors.GetByCode;
using Source.Shared.Wrapper;

namespace Source.Server.Application.Handlers;

public interface IBaseHandler
{
}

public class BaseHandler(
    ILogger<BaseHandler> logger,
    IApplicationRepositories repos,
    IGetErrorByCodeService getErrorByCodeService)
    : IBaseHandler
{
    protected readonly ILogger<BaseHandler> _logger = logger;
    protected readonly IApplicationRepositories _repos = repos;
    protected readonly IGetErrorByCodeService _getErrorByCodeService = getErrorByCodeService;

    protected async Task<IList<ErrorModel>?> ValidateRequestAsync(Func<Task<ValidationResultModel>>? func)
    {
        // Validate Header
        ValidationResultModel valResult;

        // Validate content
        if (func != null)
        {
            valResult = await func();
            if (valResult.HasError)
            {
                return valResult.Errors;
            }
        }

        return null;
    }
}
