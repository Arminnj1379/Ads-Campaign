﻿namespace ADS_Campaign.Application.DTOs.Category
{
    public class AddCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}
