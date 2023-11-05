using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Services
{
    public class AnimeService : IAnimeService
    {
        public IUnitOfWork _unitOfWork;

        public AnimeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAnime(AnimeDetails animeDetails)
        {
            if (animeDetails != null)
            {
                await _unitOfWork.Animes.Add(animeDetails);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteAnime(int AnimeId)
        {
            if (AnimeId > 0)
            {
                var animeDetails = await _unitOfWork.Animes.GetById(AnimeId);
                if (animeDetails != null)
                {
                    _unitOfWork.Animes.Delete(animeDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<AnimeDetails>> GetAllAnimes()
        {
            var animeDetailsList = await _unitOfWork.Animes.GetAll();
            return animeDetailsList;
        }

        public async Task<AnimeDetails> GetAnimeById(int animeId)
        {
            if (animeId > 0)
            {
                var animeDetails = await _unitOfWork.Animes.GetById(animeId);
                if (animeDetails != null)
                {
                    return animeDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateAnime(AnimeDetails animeDetails)
        {
            if (animeDetails != null)
            {
                var anime = await _unitOfWork.Animes.GetById(animeDetails.AnimeId);
                if(anime != null)
                {
                    anime.AnimeName= animeDetails.AnimeName;
                    anime.AnimeScore= animeDetails.AnimeScore;
                    anime.AnimeEpisodes = animeDetails.AnimeEpisodes;
                    anime.AnimeType = animeDetails.AnimeType;
                    anime.AnimeAuthor = animeDetails.AnimeAuthor;
                    anime.AnimeStudioId = animeDetails.AnimeStudioId;

                    _unitOfWork.Animes.Update(anime);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
