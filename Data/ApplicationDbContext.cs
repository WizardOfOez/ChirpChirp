using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chirp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        #region DbSets
        public DbSet<Like> Likes { get; set; } = default!;
        public DbSet<Tweet> Tweets { get; set; } = default!;
        public DbSet<Followers> Followers { get; set; } = default!;
        public DbSet<Peep> Peeps { get; set; } = default!;
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Tweet
            builder.Entity<Tweet>()
                .HasOne(t => t.ApplicationUser)
                .WithMany(u => u.Tweets)
                .HasForeignKey(t => t.ApplicationUserId);
            #endregion
            #region Like
            builder.Entity<Like>()
                .HasOne(l => l.ApplicationUser)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.ApplicationUserId);
            builder.Entity<Like>()
                .HasOne(l => l.Tweet)
                .WithMany(t => t.Likes)
                .HasForeignKey(l => l.TweetId);
            #endregion
            #region Followers
            builder.Entity<Followers>()
                .HasOne(f => f.FollowerUser)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowerUserId);
            builder.Entity<Followers>()
                .HasOne(f => f.FollowsUser)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.FollowsUserId);
            #endregion
            #region Peep
            builder.Entity<Peep>()
                .HasOne(p => p.Tweet)
                .WithMany(t => t.Peeps)
                .HasForeignKey(p => p.TweetId);
            #endregion
        }
    }
}
