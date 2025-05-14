namespace ADS_Campaign.Application.DTOs.Category
{
    public class GetByIdCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}
