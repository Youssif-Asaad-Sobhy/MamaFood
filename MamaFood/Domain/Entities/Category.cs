﻿namespace MamaFood.API.Domain.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
