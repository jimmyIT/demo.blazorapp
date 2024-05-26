using Microsoft.Extensions.Logging;
using Source.EF.Constants;
using Source.EF.Entities.User;
using Source.EF.Enums;
using Source.EF.Repositories;
using Source.Server.Application.Common.Extension.Wrapper;
using Source.Server.Application.Common.Provider;
using Source.Server.Application.Handlers;
using Source.Server.Application.Handlers.UserProfiles.Create;
using Source.Server.Application.Services.ApplicationParameters.GetValueByKey;
using Source.Server.Application.Services.Errors.GetByCode;
using Source.Shared.Wrapper;

namespace Source.Server.Aplication.Handlers.UserProfiles.Create;

public interface ICreateUserProfilesHandler : IBaseHandler
{
    Task<WrapperResult<CreateUserProfilesResponse>> DoActionAsync(CreateUserProfilesRequest request);
}

public class CreateUserProfilesHandler(
    ILogger<BaseHandler> logger,
    IApplicationRepositories repos,
    ICodeGeneratorProvider codeGeneratorProvider,
    IGetParameterValueByKeyService getParameterValueByKeySvc,
    IDateTimeProvider dateTimeProvider,
    IGetErrorByCodeService getErrorByCodeService)
    : BaseHandler(logger, repos, getErrorByCodeService), ICreateUserProfilesHandler
{
    private readonly ICodeGeneratorProvider _codeGeneratorProvider = codeGeneratorProvider;
    private readonly IGetParameterValueByKeyService _getParamValueByKeySvc = getParameterValueByKeySvc;
    private readonly IDateTimeProvider _datetimeProvider = dateTimeProvider;
    public async Task<WrapperResult<CreateUserProfilesResponse>> DoActionAsync(CreateUserProfilesRequest request)
    {
        string userCode = request.Code ?? string.Empty;

        WrapperResult<bool> autoGenerateCodeResult =
            await _getParamValueByKeySvc.GetValueAsync<bool>(ApplicationParameterConst.AutoGenerateUserCode);
        if (autoGenerateCodeResult.Succeeded is true)
        {
            bool autoGenerateCode = autoGenerateCodeResult.Data;
            if (autoGenerateCode)
            {
                IEnumerable<UserProfileEntity> lstUser = await _repos.UserProfile.GetAllAsync();
                userCode = await _codeGeneratorProvider.GenerateAsync(lstUser, null);
            }
        }

        if (string.IsNullOrEmpty(userCode))
        {
            ErrorModel getErrorResult =
                await _getErrorByCodeService.GetByKeyAsync(ErrorConst.InValidUserCodeError)
                                            .ToServiceResult();

            return await WrapperResult<CreateUserProfilesResponse>
                .FailAsync(getErrorResult);
        }

        string hashedPwd = string.Empty;
        UserProfileEntity userProfileEntity = new()
        {
            Code = userCode!,
            Name = request.Name,
            Address = request.Address,
            DateOfBirth = request.DateOfBirth,
            EmailAddress = request.EmailAddress,
            PhoneIDD = request.PhoneIDD,
            PhoneNumber = request.PhoneNumber,
            Height = request.Height,
            Weight = request.Weight,
            Photo = request.Photo,
            Status = UserStatusEnum.AddNew,
            CreatedOn = _datetimeProvider.Now(),
            Type = request.UserType,
            HashedPassword = hashedPwd             
        };

        WrapperResult<bool> useSecurityPinResult =
            await _getParamValueByKeySvc.GetValueAsync<bool>(ApplicationParameterConst.UseSecurityPin);
        if (useSecurityPinResult.Succeeded is true)
        {
            bool useSecurityPin = useSecurityPinResult.Data;
            if (useSecurityPin)
            {
                string hashedSecurityCode = string.Empty;
                userProfileEntity.HashedSecurityCode = hashedSecurityCode;
            }
        }

        await _repos.UserProfile.CreateAsync(userProfileEntity);
        await _repos.SaveAsync();

        return await WrapperResult<CreateUserProfilesResponse>
            .SuccessAsync(new CreateUserProfilesResponse()
            {
                Id = userProfileEntity.Id,
                UserCode = userProfileEntity.Code,
            });
    }
}
