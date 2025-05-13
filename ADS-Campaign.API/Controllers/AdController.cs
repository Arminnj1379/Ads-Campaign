using System.Security.Claims;
using ADS_Campaign.Application.DTOs.Ad;
using ADS_Campaign.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ADS_Campaign.API.Controllers
{
    public class AdController : BaseController
    {
        private readonly IAdService _adService;
        public AdController(IAdService adService)
        {
            _adService = adService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(AddAdDto dto)
        {
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            dto.UserId = UserId;
            await _adService.AddAsync(dto, UserId);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _adService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserIdAsync()
        {
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _adService.GetByUserIdAsync(UserId);
            return Ok(result);
        }
    }
}
