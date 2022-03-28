using FD.ShortUrl.Api;
using FD.ShortUrl.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddMvc();
builder.Services.AddScoped<IBrainstormSessionRepository,EFStormSessionRepository>();

builder.Services.AddControllers();



//builder.Services.AddDbContext<ApplicationDbContext>(opt =>
//    opt.UseOracle(configuration.GetConnectionString("baseDb")));
builder.Services.AddDbContext<BrainStormDb>(opt =>
opt.UseInMemoryDatabase("ContactDb"));

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var repository = scope.ServiceProvider.GetRequiredService<IBrainstormSessionRepository>();
        BrainInitialzie.InitializeDatabaseAsync(repository).Wait();
    }
}

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //mvc

app.Run();

