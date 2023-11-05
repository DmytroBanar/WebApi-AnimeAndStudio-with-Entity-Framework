using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public IAnimeRepository Animes { get; }
        public IAnimeStudioRepository Studios { get; }

        public UnitOfWork(DbContextClass dbContext, IAnimeRepository animeRepository, IAnimeStudioRepository studioRepository)
        {
            _dbContext = dbContext;
            Animes = animeRepository;
            Studios = studioRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
    public class UnitOfWorkFactory
    {
        private readonly DbContextClass _dbContext;
        private readonly IAnimeRepository _animeRepository;
        private readonly IAnimeStudioRepository _studioRepository;

        public UnitOfWorkFactory(DbContextClass dbContext, IAnimeRepository animeRepository, IAnimeStudioRepository studioRepository)
        {
            _dbContext = dbContext;
            _animeRepository = animeRepository;
            _studioRepository = studioRepository;
        }

        public IUnitOfWork CreateTeamUnitOfWork()
        {
            return new UnitOfWork(_dbContext, _animeRepository, _studioRepository);
        }

        public IUnitOfWork CreateLeagueUnitOfWork()
        {
            return new UnitOfWork(_dbContext, _animeRepository, _studioRepository);
        }
    }

}
