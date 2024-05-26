using Source.EF.Bases.Repo;
using Source.EF.Contexts;
using Source.EF.Entities.User;

namespace Source.EF.Repositories.User;
public interface IUserProfilesRepository : IBaseRepository<UserProfileEntity>
{
}

public class UserProfilesRepository(ApplicationDbContext dbContext)
    : BaseRepository<UserProfileEntity>(dbContext), IUserProfilesRepository
{
}
