namespace MamaFood.API.Domain.Entities
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Byte[] Photo { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderFood> OrderFoods { get; set; }
    }
}
