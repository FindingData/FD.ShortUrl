using FD.ShortUrl.Api;
using FD.ShortUrl.Core;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddRazorPages();
builder.Services.AddScoped<IQuoteService, QuoteService>();


//builder.Services.AddControllers();
builder.Services.AddDbContext<TodoDb>(opt =>
opt.UseInMemoryDatabase("TodoDb"));

builder.Services.AddDefaultIdentity<IdentityUser>()
      .AddEntityFrameworkStores<TodoDb>();

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/SecurePage");
    options.Conventions.AuthorizePage("/Index");
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TodoDb>();
    db.Database.EnsureCreated();
    try
    {
        db.Initialize();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the database. Error: {Message}", ex.Message);
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

//app.MapRazorPages();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}"); //mvc

app.Run();



public partial class Program { }