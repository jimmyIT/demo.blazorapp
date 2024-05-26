using Microsoft.Extensions.Logging;
using Source.Server.Aplication.Handlers.UserProfiles.Create;
using Source.Server.Application.Handlers.UserProfiles.GenerateCode;
using Source.Server.Application.Handlers.UserProfiles.GetByCode;

namespace Source.Server.Application.Wrappers.UserProfiles;
public interface IUserProfilesWrapper : IBaseWrapper
{
    IGetUserProfileByCodeHandler GetByCodeHandler { get; }
    ICreateUserProfilesHandler CreateHandler { get; }
    IGenerateUserProfileCodeHandler GenerateUserProfileCodeHandler { get; }
}

public class UserProfilesWrapper(
    ILogger<BaseWrapper> logger,
    IGetUserProfileByCodeHandler getUserProfileByCodeHandler,
    ICreateUserProfilesHandler createUserProfilesHandler,
    IGenerateUserProfileCodeHandler generateUserProfileCodeHandler)
    : BaseWrapper(logger), IUserProfilesWrapper
{
    private readonly IGetUserProfileByCodeHandler _getUserProfileByCodeHandler = getUserProfileByCodeHandler;
    private readonly ICreateUserProfilesHandler _createUserProfilesHandler = createUserProfilesHandler;
    private readonly IGenerateUserProfileCodeHandler _generateUserProfileCodeHandler = generateUserProfileCodeHandler;

    public IGetUserProfileByCodeHandler GetByCodeHandler => _getUserProfileByCodeHandler;

    public ICreateUserProfilesHandler CreateHandler => _createUserProfilesHandler;

    public IGenerateUserProfileCodeHandler GenerateUserProfileCodeHandler => _generateUserProfileCodeHandler;
}
