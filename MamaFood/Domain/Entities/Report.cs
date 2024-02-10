using MamaFood.API.Domain.Enum;

namespace MamaFood.API.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public ReportType Type { get; set; }
        public required string CreatorId { get; set; }
        public required string AccusedId { get; set; }
        public required ApplicationUser AccusedUser { get; set; }
        public required ApplicationUser CreatorUser { get; set; }
    }
}
