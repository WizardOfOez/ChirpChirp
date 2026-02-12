using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace Chirp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? Location { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? ProfilePictureContentType { get; set; }
        public byte[]? BackgroundPicture { get; set; }
        public string? BackgroundPictureContentType { get; set; }

        // Navigation property für die Beziehung zu Tweets
        public ICollection<Tweet>? Tweets { get; set; }

        // Navigation property für die Beziehung zu Likes
        public ICollection<Like>? Likes { get; set; }

        // Navigation properties für die Beziehung zu Followers
        public ICollection<Followers>? Followers { get; set; }
        public ICollection<Followers>? Following { get; set; }
    }

}
