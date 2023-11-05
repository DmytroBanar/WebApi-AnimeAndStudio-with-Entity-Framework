using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeStudioController : ControllerBase
    {
        public readonly IAnimeStudioService _studioService;
        public AnimeStudioController(IAnimeStudioService studioService)
        {
            _studioService = studioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudioList()
        {
            var studioDetailsList = await _studioService.GetAllStudios();
            if (studioDetailsList == null)
            {
                return NotFound();
            }
            return Ok(studioDetailsList);
        }

        [HttpGet("{studioId}")]
        public async Task<IActionResult> GetStudioById(int studioId)
        {
            var studioDetails = await _studioService.GetStudioById(studioId);

            if (studioDetails != null)
            {
                return Ok(studioDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudio(AnimeStudioDetails studioDetails)
        {
            var isStudioCreated = await _studioService.CreateStudio(studioDetails);

            if (isStudioCreated)
            {
                return Ok(isStudioCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudio(AnimeStudioDetails studioDetails)
        {
            if (studioDetails != null)
            {
                var isStudioCreated = await _studioService.UpdateStudio(studioDetails);
                if (isStudioCreated)
                {
                    return Ok(isStudioCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{studioId}")]
        public async Task<IActionResult> DeleteStudioe(int studioId)
        {
            var isStudioCreated = await _studioService.DeleteStudio(studioId);

            if (isStudioCreated)
            {
                return Ok(isStudioCreated);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
