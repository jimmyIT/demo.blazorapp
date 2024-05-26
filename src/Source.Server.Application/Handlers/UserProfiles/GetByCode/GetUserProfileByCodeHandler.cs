using Microsoft.Extensions.Logging;
using Source.EF.Repositories;
using Source.Server.Application.Services.Errors.GetByCode;
using Source.Shared.Wrapper;

namespace Source.Server.Application.Handlers.UserProfiles.GetByCode;
public interface IGetUserProfileByCodeHandler : IBaseHandler
{
    Task<WrapperResult<GetUserProfileByCodeResponse>> DoActionAsync(string code);
}

public class GetUserProfileByCodeHandler(
    ILogger<BaseHandler> logger,
    IApplicationRepositories repos,
    IGetErrorByCodeService getErrorByCodeService)
    : BaseHandler(logger, repos, getErrorByCodeService), IGetUserProfileByCodeHandler
{
    public Task<WrapperResult<GetUserProfileByCodeResponse>> DoActionAsync(string code)
    {
        throw new NotImplementedException();
    }
}
