namespace Chirp.Data
{
    public class Followers
    {
        public int Id { get; set; }
        // Foreign key zur bestehenden Identity-Klasse
        // User der dem anderen User folgt
        public string? FollowerUserId { get; set; }
        // Foreign key zur bestehenden Identity-Klasse
        // User der gefolgt wird
        public string? FollowsUserId { get; set; }

        // Navigation properties
        public ApplicationUser? FollowerUser { get; set; }
        public ApplicationUser? FollowsUser { get; set; }
    }
}
