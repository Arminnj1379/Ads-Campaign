using ADS_Campaign.Application.DTOs.AdImage;
using ADS_Campaign.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADS_Campaign.API.Controllers
{
    public class UploadController : BaseController
    {
        private readonly IAdImageService _adImageService;
        public UploadController(IAdImageService adImageService)
        {
            _adImageService = adImageService;
        }
        [HttpPost("UploadFile")]
        [Consumes("multipart/form-data")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromBody] AddAdImageDto imageDto)
        {
            if (file == null || file.Length == 0)
                return BadRequest("فایلی ارسال نشده است.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            imageDto.ImageUrl = "/UploadedFiles/" + file.FileName;
            await _adImageService.AddAsync(imageDto);
            return Ok(new { message = "فایل با موفقیت آپلود شد", URL = "/UploadedFiles/" + file.FileName });
        }
    }
}
