namespace MamaFood.API.Domain.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int OrderID { get; set; }
        public Review Review { get; set; }
        public ICollection<OrderFood> OrderFoods { get; set; }
    }
}
