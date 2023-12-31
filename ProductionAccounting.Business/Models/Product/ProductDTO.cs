﻿using ProductionAccounting.Application.Models.Category;

namespace ProductionAccounting.Application.Models.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public decimal Cost { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
