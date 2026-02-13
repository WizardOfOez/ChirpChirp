using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace Chirp.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Bio { get; set; }
        public string? Location { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? ProfilePictureContentType { get; set; }
        public byte[]? BackgroundPicture { get; set; }
        public string? BackgroundPictureContentType { get; set; }

        public ICollection<Tweet>? Tweets { get; set; }
        public ICollection<Like>? Likes { get; set; }

        public ICollection<Followers>? Followers { get; set; }
        public ICollection<Followers>? Following { get; set; }
    }

}
