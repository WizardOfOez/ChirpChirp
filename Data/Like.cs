using static System.Net.Mime.MediaTypeNames;

namespace Chirp.Data
{
    public class Like
    {
        public int Id { get; set; }

        public string? ApplicationUserId { get; set; }
        public int? TweetId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }
        public Tweet? Tweet { get; set; }
    }
}
