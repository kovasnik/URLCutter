using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using URLCutter.BLL.Interfaces;
using URLCutter.DTO;

namespace URLCutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortURLController : ControllerBase
    {
        private readonly IShortUrlService _shortUrlService;
        public ShortURLController(IShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUrls()
        {
            var urls = await _shortUrlService.GetAllAsync();
            return Ok(urls);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUrl([FromBody] AddShortUrlDTO addShortUrlDTO)
        {
            var result = await _shortUrlService.AddAsync(addShortUrlDTO);
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrl(int id)
        {
            var result = await _shortUrlService.DeleteAsync(id);
            if (result)
                return NoContent();

            return NotFound();
        }
    }
}
