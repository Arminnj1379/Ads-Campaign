﻿namespace ADS_Campaign.Application.DTOs.Category
{
    public class AllCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public string IconClass { get; set; }
    }
}
