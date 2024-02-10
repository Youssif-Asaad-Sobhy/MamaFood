namespace MamaFood.API.Domain.Entities
{
    public class UserLikeFood
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public required string FoodId { get; set; }
        public required ApplicationUser Users { get; set; }
        public required Food Food { get; set; }
    }
}
