using FD.ShortUrl.Api;
using FD.ShortUrl.Auth.Data;
using FD.ShortUrl.Core;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(connectionString, o =>o.MigrationsAssembly("FD.ShortUrl.Api"))) ;
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDbContext<TodoDb>(opt =>
opt.UseInMemoryDatabase("TodoDb"));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Index");
});

builder.Services.AddScoped<IQuoteService, QuoteService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddTransient<IClaimsTransformation, MyClaimsTransformation>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
  .AddCookie()
  .AddOpenIdConnect(options =>
  {
      options.SignInScheme = "Cookies";
      options.Authority = "-your-identity-provider-";
      options.RequireHttpsMetadata = true;
      options.ClientId = "-your-clientid-";
      options.ClientSecret = "-your-client-secret-from-user-secrets-or-keyvault";
      options.ResponseType = "code";
      options.UsePkce = true;
      options.Scope.Add("profile");
      options.SaveTokens = true;

      options.GetClaimsFromUserInfoEndpoint = true;
      options.ClaimActions.MapUniqueJsonKey("preferred_username",
                                            "preferred_username");
      options.ClaimActions.MapUniqueJsonKey("gender", "gender");

      // Other options...
      options.TokenValidationParameters = new TokenValidationParameters
      {
          NameClaimType = "email"
          //, RoleClaimType = "role"
      };
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

public partial class Program { }