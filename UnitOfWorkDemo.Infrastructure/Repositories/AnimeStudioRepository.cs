using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public class AnimeStudioRepository : GenericRepository<AnimeStudioDetails>, IAnimeStudioRepository
    {
        public AnimeStudioRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
