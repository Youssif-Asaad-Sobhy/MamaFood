namespace MamaFood.API.Domain.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string USerId { get; set; }
        public required ApplicationUser User { get; set; }
        public required List<Food> Foods { get; set; }
    }
}
