using Chirp.Components;
using Chirp.Components.Account;
using Chirp.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddHubOptions(options =>
    {
        options.MaximumReceiveMessageSize = 32 * 1024 * 1024; // 32 MB
    });

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

app.MapGet("/images/{id}", async (int id, IDbContextFactory<ApplicationDbContext> factory) =>
{
    ApplicationDbContext dbContext = await factory.CreateDbContextAsync();
    var tweet = await dbContext.Tweets.FindAsync(id);
    if (tweet == null || tweet.Image == null || tweet.ContentType == null)
    {
        return Results.NotFound();
    }
    return Results.File(tweet.Image, tweet.ContentType);
});

app.MapGet("/images/background/{userid}", async (string userid, IDbContextFactory<ApplicationDbContext> factory) =>
{
    ApplicationDbContext dbContext = await factory.CreateDbContextAsync();
    var user = await dbContext.Users.FindAsync(userid);
    if (user == null || user.BackgroundPicture == null || user.BackgroundPictureContentType == null)
    {
        return Results.NotFound();
    }
    return Results.File(user.BackgroundPicture, user.BackgroundPictureContentType);
});
app.MapGet("/images/profile/{userid}", async (string userid, IDbContextFactory<ApplicationDbContext> factory) =>
{
    ApplicationDbContext dbContext = await factory.CreateDbContextAsync();
    var user = await dbContext.Users.FindAsync(userid);
    if (user == null || user.ProfilePicture == null || user.ProfilePictureContentType == null)
    {
        return Results.NotFound();
    }
    return Results.File(user.ProfilePicture, user.ProfilePictureContentType);
});
app.Run();