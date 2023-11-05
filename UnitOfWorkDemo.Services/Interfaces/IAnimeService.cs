using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Services.Interfaces
{
    public interface IAnimeService
    {
        Task<bool> CreateAnime(AnimeDetails animeDetails);

        Task<IEnumerable<AnimeDetails>> GetAllAnimes();

        Task<AnimeDetails> GetAnimeById(int AnimeId);

        Task<bool> UpdateAnime(AnimeDetails animeDetails);

        Task<bool> DeleteAnime(int animeId);
    }
}
