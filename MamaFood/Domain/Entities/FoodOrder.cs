namespace MamaFood.API.Domain.Entities
{
    public class FoodOrder
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int FoodId { get; set; }
        public int OrderId { get; set; }
        public required Food Food { get; set; }
        public required Order Order { get; set; }
    }
}
