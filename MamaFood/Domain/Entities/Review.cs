namespace MamaFood.API.Domain.Entities
{
    public class Review
    {
        public int ID { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
        public int OrderID { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
    }
}
