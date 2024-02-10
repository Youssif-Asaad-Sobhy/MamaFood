namespace MamaFood.API.Domain.Entities
{
    public class FoodCategory
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int CategoryId { get; set; }
        public required Food Food { get; set; }
        public required Category Category { get; set; }
    }
}
