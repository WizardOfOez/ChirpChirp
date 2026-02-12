using System.ComponentModel.DataAnnotations;

namespace Chirp.Data
{
    public class Tweet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Der Text des Tweets ist erforderlich.")]
        [MaxLength(280, ErrorMessage = "Der Text des Tweets darf maximal 280 Zeichen lang sein.")]
        public string? Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public byte[]? Image { get; set; }
        public string? ContentType { get; set; }

        // Foreign key zur bestehenden Identity-Klasse
        public string? ApplicationUserId { get; set; }

        // Navigation property für die Beziehung zu ApplicationUser
        public ApplicationUser? ApplicationUser { get; set; }
        // Navigation property für die Beziehung zu Likes
        public ICollection<Like>? Likes { get; set; }
    }
}
