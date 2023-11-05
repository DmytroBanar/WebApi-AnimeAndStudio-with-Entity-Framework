using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Services.Interfaces
{
    public interface IAnimeStudioService
    {
        Task<bool> CreateStudio(AnimeStudioDetails studioDetails);

        Task<IEnumerable<AnimeStudioDetails>> GetAllStudios();

        Task<AnimeStudioDetails> GetStudioById(int studioId);

        Task<bool> UpdateStudio(AnimeStudioDetails studioDetails);

        Task<bool> DeleteStudio(int studioId);
    }
}
