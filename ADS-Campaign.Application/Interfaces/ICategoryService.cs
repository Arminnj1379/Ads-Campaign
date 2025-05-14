using ADS_Campaign.Application.DTOs.Category;

namespace ADS_Campaign.Application.Interfaces
{
    public interface ICategoryService
    {

        Task AddAsync(AddCategoryDto categoryDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, UpdateCategoryDto categoryDto);
        Task<List<AllCategoryDto>> GetAllAsync();
        Task<GetByIdCategoryDto> GetByIdAsync(int id);
    }
}
