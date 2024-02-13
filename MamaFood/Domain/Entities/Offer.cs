namespace MamaFood.API.Domain.Entities
{
    public class Offer
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string UserId { get; set; }
        public required int SpecialRequestId { get; set; }
        public required ApplicationUser User { get; set; }
        public required SpecialRequest SpecialRequest { get; set;}

    }
}
