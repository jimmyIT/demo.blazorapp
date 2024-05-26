using Source.EF.Bases.Repo;
using Source.EF.Contexts;
using Source.EF.Entities.User;

namespace Source.EF.Repositories.User;

public interface ISessionInfomationRepository : IBaseRepository<SessionInfomationEntity>
{
}

public class SessionInfomationRepository(ApplicationDbContext dbContext)
    : BaseRepository<SessionInfomationEntity>(dbContext), ISessionInfomationRepository
{
}
