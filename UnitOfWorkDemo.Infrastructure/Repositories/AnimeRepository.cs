using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public class AnimeRepository : GenericRepository<AnimeDetails>, IAnimeRepository
    {
        public AnimeRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
