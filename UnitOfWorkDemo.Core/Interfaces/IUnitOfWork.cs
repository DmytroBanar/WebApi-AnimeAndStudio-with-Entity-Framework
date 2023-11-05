

namespace UnitOfWorkDemo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAnimeRepository Animes { get; }
        IAnimeStudioRepository Studios { get; }

        int Save();
    }
}
