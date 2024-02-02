namespace MamaFood.API.Domain.Entities
{
    public class UserFood
    {
        public int ID { get; set; }
        public int FoodID { get; set; }
        public int UserID { get; set; }
        public int Price {  get; set; }
        public string Description { get; set; }
    }
}
