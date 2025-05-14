using ADS_Campaign.Application.DTOs.Category;
using ADS_Campaign.Application.Interfaces;
using ADS_Campaign.Application.Mapper;
using ADS_Campaign.Domain;
using AutoMapper;

namespace ADS_Campaign.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddCategoryDto categoryDto)
        {
            await _unitOfWork.CategoryRepository.AddAsync(categoryDto.Factory());
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.CategoryRepository.DeleteAsync(id);
            await _unitOfWork.Save();
        }

        public async Task UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            await _unitOfWork.Save();
        }

        public async Task<List<AllCategoryDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            return categories.AllCategoryDto();
        }

        public async Task<GetByIdCategoryDto> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            return category.GetByIdCategoryDto();
        }
    }
}
