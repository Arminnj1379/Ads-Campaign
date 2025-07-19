using ADS_Campaign.Application.DTOs.Category;
using ADS_Campaign.Domain.Entities.Categories;

namespace ADS_Campaign.Application.Mapper
{
    public static class CategoryMapper
    {
        public static Category Factory(this AddCategoryDto categoryDto)
        {
            return new Category
            {
                Description = categoryDto.Description,
                CreatedAt = DateTime.Now,
                Name = categoryDto.Name,
                ParentId = categoryDto.ParentId,
            };
        }

        public static GetByIdCategoryDto GetByIdCategoryDto(this Category categoryDto)
        {
            return new GetByIdCategoryDto
            {
                ParentId = categoryDto.ParentId,
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                Id = categoryDto.Id,
            };
        }

        public static List<AllCategoryDto> AllCategoryDto(this List<Category> categoriesDto)
        {
            return categoriesDto.Select(categoryDto => new AllCategoryDto
            {
                ParentId = categoryDto.ParentId,
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                Id = categoryDto.Id,
                IconClass = categoryDto.IconClass,
            }).ToList();
        }
    }
}
