namespace MamaFood.API.Domain.Entities
{
    public class SpecialRequest
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public required string UserId { get; set; }
        public Order? Order { get; set; }
        public required ApplicationUser User { get; set; }
        public List<Offer>? Offers { get; set; }
    }
}
