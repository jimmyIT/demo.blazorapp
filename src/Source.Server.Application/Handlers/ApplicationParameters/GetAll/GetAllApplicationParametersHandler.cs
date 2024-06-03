using Microsoft.Extensions.Logging;
using Source.EF.Entities.Parameters;
using Source.EF.Repositories;
using Source.Server.Application.Services.Internal.Errors.GetByCode;
using Source.Shared.Wrapper;

namespace Source.Server.Application.Handlers.ApplicationParameters.GetAll;

public interface IGetAllApplicationParametersHandler
{
    Task<WrapperResult<GetAllApplicationParametersResponse>> DoActionAsync();
}

public class GetAllApplicationParametersHandler(
    ILogger<BaseHandler> logger,
    IApplicationRepositories repos,
    IGetErrorByCodeService getErrorByCodeService)
    : BaseHandler(logger, repos, getErrorByCodeService), IGetAllApplicationParametersHandler
{
    public async Task<WrapperResult<GetAllApplicationParametersResponse>> DoActionAsync()
    {
        GetAllApplicationParametersResponse response = new();

        IEnumerable<ApplicationParameterEntity> lstParams = await _repos.ApplicationParameter.GetAllAsync();
        if (lstParams != null && lstParams.Count() > 0)
        {
            Dictionary<string, object> keyValuePairs = [];
            foreach (ApplicationParameterEntity appParam in lstParams)
            {
                keyValuePairs.Add(appParam.Code, appParam.Value);
            }

            response.Parameters = keyValuePairs;
        }

        return await WrapperResult<GetAllApplicationParametersResponse>.SuccessAsync(response);
    }
}
