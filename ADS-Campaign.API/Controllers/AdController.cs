using ADS_Campaign.Application.DTOs.Ad;
using ADS_Campaign.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ADS_Campaign.API.Controllers
{
    public class AdController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IAdService _adService;
        public AdController(IAdService adService, IWebHostEnvironment env)
        {
            _adService = adService;
            _env = env;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromForm] AddAdDto dto)
        {
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            dto.UserId = UserId;
            var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsPath);

            var fileName = Guid.NewGuid() + Path.GetExtension(dto.image.FileName);
            var filePath = Path.Combine(uploadsPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await dto.image.CopyToAsync(stream);

            var imageUrl = $"/uploads/{fileName}";
            await _adService.AddAsync(dto, UserId, imageUrl);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
        {
            await _adService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] Guid id, [FromBody] UpdateAdDto adDto)
        {
            await _adService.UpdateAsync(id, adDto);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
        {
            var result = await _adService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync([FromBody] AdFilter? adFilter)
        {
            var result = await _adService.GetAllAsync(adFilter);
            return Ok(result);
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserIdAsync()
        {
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _adService.GetByUserIdAsync(UserId);
            return Ok(result);
        }

        [HttpPost("IncrementViewCount")]
        public async Task<IActionResult> IncrementViewCountAsync([FromQuery] Guid adId, CancellationToken cancellationToken)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            await _adService.IncrementViewCountAsync(adId, ip, cancellationToken);
            return Ok();
        }

        [HttpGet("GetRelatedAdsWithImages")]
        public async Task<IActionResult> GetRelatedAdsWithImagesAsync([FromQuery] Guid adId)
        {
            var result = await _adService.GetRelatedAdsWithImagesAsync(adId);
            return Ok(result);
        }
    }
}
