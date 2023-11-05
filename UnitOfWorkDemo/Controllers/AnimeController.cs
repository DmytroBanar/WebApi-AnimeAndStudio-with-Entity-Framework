using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        public readonly IAnimeService _animeService;
        public AnimeController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAnimeList()
        {
            var animeDetailsList = await _animeService.GetAllAnimes();
            if(animeDetailsList == null)
            {
                return NotFound();
            }
            return Ok(animeDetailsList);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{animeId}")]
        public async Task<IActionResult> GetAnimeById(int animeId)
        {
            var animeDetails = await _animeService.GetAnimeById(animeId);

            if (animeDetails != null)
            {
                return Ok(animeDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAnime(AnimeDetails animeDetails)
        {
            var isAnimeCreated = await _animeService.CreateAnime(animeDetails);

            if (isAnimeCreated)
            {
                return Ok(isAnimeCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update the product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAnime(AnimeDetails animeDetails)
        {
            if (animeDetails != null)
            {
                var isAnimeCreated = await _animeService.UpdateAnime(animeDetails);
                if (isAnimeCreated)
                {
                    return Ok(isAnimeCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("{animeId}")]
        public async Task<IActionResult> DeleteAnime(int animeId)
        {
            var isAnimeCreated = await _animeService.DeleteAnime(animeId);

            if (isAnimeCreated)
            {
                return Ok(isAnimeCreated);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
