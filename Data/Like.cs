using static System.Net.Mime.MediaTypeNames;

namespace Chirp.Data
{
    public class Like
    {
        public int Id { get; set; }

        // Foreign key zur bestehenden Identity-Klasse
        public string? ApplicationUserId { get; set; }
        // Foreign key zum Tweet
        public int? TweetId { get; set; }

        // Navigation properties
        public ApplicationUser? ApplicationUser { get; set; }
        // Navigation property zum Tweet
        public Tweet? Tweet { get; set; }
    }
}
