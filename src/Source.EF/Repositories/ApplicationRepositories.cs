using Source.EF.Contexts;
using Source.EF.Repositories.Error;
using Source.EF.Repositories.Parameter;
using Source.EF.Repositories.User;

namespace Source.EF.Repositories;
public interface IApplicationRepositories
{
    IUserProfilesRepository UserProfile { get; }
    ISessionInfomationRepository SessionInfomation { get; }
    IApplicationParameterRepository ApplicationParameter { get; }
    IErrorRepository Error { get; }
    Task SaveAsync();
}

public class ApplicationRepositories(
        ApplicationDbContext dbContext,
        IUserProfilesRepository userProfilesRepository,
        ISessionInfomationRepository sessionInfomationRepository,
        IApplicationParameterRepository applicationParameterRepository,
        IErrorRepository errorRepository)
    : IApplicationRepositories
{
    private readonly ApplicationDbContext _context = dbContext;
    private readonly IUserProfilesRepository _userProfileRepo = userProfilesRepository;
    private readonly ISessionInfomationRepository _sessionInfomationRepo = sessionInfomationRepository;
    private readonly IApplicationParameterRepository _applicationParameterRepo = applicationParameterRepository;
    private readonly IErrorRepository _errorRepository = errorRepository;

    /// <summary>
    /// User Profile Repository
    /// </summary>
    public IUserProfilesRepository UserProfile => _userProfileRepo;

    /// <summary>
    /// Session Infomation Repository
    /// </summary>
    public ISessionInfomationRepository SessionInfomation => _sessionInfomationRepo;

    /// <summary>
    /// Application Parameter Repository
    /// </summary>
    public IApplicationParameterRepository ApplicationParameter => _applicationParameterRepo;

    /// <summary>
    /// Error Repository
    /// </summary>
    public IErrorRepository Error => _errorRepository;

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();
}
