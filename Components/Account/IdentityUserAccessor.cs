using Chirp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Chirp.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<ApplicationUser> userManager, IdentityRedirectManager redirectManager, IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        public async Task<ApplicationUser> GetRequiredUserAsync(HttpContext context)
        {
            var userId = userManager.GetUserId(context.User);
            
            if (string.IsNullOrEmpty(userId))
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", "Error: Unable to load user.", context);
                return null!;
            }

            // Use a fresh DbContext to avoid concurrency issues
            using (var dbContext = await dbContextFactory.CreateDbContextAsync())
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
                
                if (user is null)
                {
                    redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userId}'.", context);
                }

                return user!;
            }
        }
    }
}
