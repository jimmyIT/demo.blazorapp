using Source.EF.Bases.Repo;
using Source.EF.Contexts;
using Source.EF.Entities.Error;

namespace Source.EF.Repositories.Error;

public interface IErrorRepository : IBaseRepository<ErrorEntity>
{
}

public class ErrorRepository(ApplicationDbContext dbContext)
    : BaseRepository<ErrorEntity>(dbContext), IErrorRepository
{
}
