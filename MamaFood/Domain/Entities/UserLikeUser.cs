namespace MamaFood.API.Domain.Entities
{
    public class UserLikeUser
    {
        public int Id { get; set; }
        public required string FollowerId { get; set; }
        public required string FollowingId { get; set; }
        public required ApplicationUser User { get; set; }
    }
}
