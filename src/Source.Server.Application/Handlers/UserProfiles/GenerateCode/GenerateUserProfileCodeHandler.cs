using Microsoft.Extensions.Logging;
using Source.EF.Entities.User;
using Source.EF.Repositories;
using Source.Server.Application.Common.Provider;
using Source.Server.Application.Services.Errors.GetByCode;
using Source.Shared.Wrapper;

namespace Source.Server.Application.Handlers.UserProfiles.GenerateCode;
public interface IGenerateUserProfileCodeHandler : IBaseHandler
{
    Task<WrapperResult<string>> DoActionAsync();
}

public class GenerateUserProfileCodeHandler(
    ILogger<BaseHandler> logger,
    IApplicationRepositories repos,
    ICodeGeneratorProvider codeGeneratorProvider,
    IGetErrorByCodeService getErrorByCodeService)
    : BaseHandler(logger, repos, getErrorByCodeService), IGenerateUserProfileCodeHandler
{
    private readonly ICodeGeneratorProvider _codeGeneratorProvider = codeGeneratorProvider;

    public async Task<WrapperResult<string>> DoActionAsync()
    {
        IEnumerable<UserProfileEntity> lstUser = await _repos.UserProfile.GetAllAsync();

        string code = await _codeGeneratorProvider.GenerateAsync(lstUser, null);

        return await WrapperResult<string>.SuccessAsync(code);
    }
}
