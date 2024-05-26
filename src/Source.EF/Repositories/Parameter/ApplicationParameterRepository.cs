using Source.EF.Bases.Repo;
using Source.EF.Contexts;
using Source.EF.Entities.Parameters;

namespace Source.EF.Repositories.Parameter;

public interface IApplicationParameterRepository : IBaseRepository<ApplicationParameterEntity>
{
}

public class ApplicationParameterRepository(ApplicationDbContext dbContext)
    : BaseRepository<ApplicationParameterEntity>(dbContext), IApplicationParameterRepository
{
}
