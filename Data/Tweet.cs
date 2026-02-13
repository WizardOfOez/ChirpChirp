using System.ComponentModel.DataAnnotations;

namespace Chirp.Data
{
    public class Tweet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Der Text des Tweets ist erforderlich.")]
        [MaxLength(123, ErrorMessage = "Der Text des Tweets darf maximal 123 Zeichen lang sein.")]
        public string? Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public byte[]? Image { get; set; }
        public string? ContentType { get; set; }

        public string? ApplicationUserId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }
        public ICollection<Like>? Likes { get; set; }
        
        public ICollection<Peep>? Peeps { get; set; }
    }
}
