using FD.ShortUrl.Api;
using FD.ShortUrl.Auth.Data;
using FD.ShortUrl.Core;
using FD.ShortUrl.Domain;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApiAuthDbContext>(options =>
    options.UseSqlServer(connectionString, o => o.MigrationsAssembly("FD.ShortUrl.Api"))
    .UseLazyLoadingProxies())
    .AddIdentity<ApiApplicationUser, ApiApplicationRole>(options => {
        options.SignIn.RequireConfirmedAccount = true;
        options.Tokens.ProviderMap.Add("CustomEmailConfirmation",
            new TokenProviderDescriptor(typeof(CustomEmailConfirmationTokenProvider<ApiApplicationUser>)));
        options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
        })
     .AddTokenProvider("Default", typeof(HedgehogEmailTwoFactorAuthentication<ApiApplicationUser>))
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApiAuthDbContext>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Forbidden/";
});

builder.Services.AddTransient<CustomEmailConfirmationTokenProvider<ApiApplicationUser>>();

builder.Services.AddScoped<IUserTwoFactorTokenProvider<ApiApplicationUser>, HedgehogEmailTwoFactorAuthentication<ApiApplicationUser>>();
        

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDbContext<TodoDb>(opt =>
opt.UseInMemoryDatabase("TodoDb"));




builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Index");
});

builder.Services.AddScoped<IQuoteService, QuoteService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;

    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.Cookie.Name = "fd.short-url";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Identity/Account/Login";
    // ReturnUrlParameter requires 
    //using Microsoft.AspNetCore.Authentication.Cookies;
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});


builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
       o.TokenLifespan = TimeSpan.FromMinutes(1));


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

var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
};
app.UseCookiePolicy(cookiePolicyOptions);

app.MapRazorPages();

app.Run();

public partial class Program { }