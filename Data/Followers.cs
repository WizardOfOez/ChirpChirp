namespace Chirp.Data
{
    public class Followers
    {
        public int Id { get; set; }
        public string? FollowerUserId { get; set; }
        public string? FollowsUserId { get; set; }

        public ApplicationUser? FollowerUser { get; set; }
        public ApplicationUser? FollowsUser { get; set; }
    }
}
