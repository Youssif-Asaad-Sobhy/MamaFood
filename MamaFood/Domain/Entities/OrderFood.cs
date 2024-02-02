namespace MamaFood.API.Domain.Entities
{
    public class OrderFood
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int FoodID { get; set; }
        public int OrderID { get; set; }
        public Food Food { get; set; }
        public Order Order { get; set; }
    }
}
