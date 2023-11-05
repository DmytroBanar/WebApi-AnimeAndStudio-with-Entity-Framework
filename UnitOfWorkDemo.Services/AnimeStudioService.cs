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
    public class AnimeStudioService : IAnimeStudioService
    {
        public IUnitOfWork _unitOfWork;

        public AnimeStudioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateStudio(AnimeStudioDetails studioDetails)
        {
            if (studioDetails != null)
            {
                await _unitOfWork.Studios.Add(studioDetails);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteStudio(int StudioId)
        {
            if (StudioId > 0)
            {
                var studioDetails = await _unitOfWork.Studios.GetById(StudioId);
                if (studioDetails != null)
                {
                    _unitOfWork.Studios.Delete(studioDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<AnimeStudioDetails>> GetAllStudios()
        {
            var studioDetailsList = await _unitOfWork.Studios.GetAll();
            return studioDetailsList;
        }

        public async Task<AnimeStudioDetails> GetStudioById(int studioId)
        {
            if (studioId > 0)
            {
                var studioDetails = await _unitOfWork.Studios.GetById(studioId);
                if (studioDetails != null)
                {
                    return studioDetails;
                }
            }
            return null;
        }


        public async Task<bool> UpdateStudio(AnimeStudioDetails studioDetails)
        {
            if (studioDetails != null)
            {
                var studio = await _unitOfWork.Studios.GetById(studioDetails.StudioId);
                if (studio != null)
                {
                    studio.StudioName = studioDetails.StudioName;
                    studio.StudioCountry = studioDetails.StudioCountry;
                    studio.StudioNumProjects = studioDetails.StudioNumProjects;
                    studio.StudioMPWork = studioDetails.StudioMPWork;
                    
                    _unitOfWork.Studios.Update(studio);

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
