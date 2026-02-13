namespace Chirp.Data
{
    public class Peep
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int TweetId { get; set; }
        public Tweet? Tweet { get; set; }
    }
}
