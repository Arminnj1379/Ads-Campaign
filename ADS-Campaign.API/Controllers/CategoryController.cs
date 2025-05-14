using ADS_Campaign.Application.DTOs.Ad;
using ADS_Campaign.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ADS_Campaign.Application.DTOs.Category;

namespace ADS_Campaign.API.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(AddCategoryDto dto)
        {
            await _categoryService.AddAsync(dto);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] int id, [FromBody] UpdateCategoryDto Dto)
        {
            await _categoryService.UpdateAsync(id, Dto);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _categoryService.GetAllAsync();
            return Ok(result);
        }
    }
}
