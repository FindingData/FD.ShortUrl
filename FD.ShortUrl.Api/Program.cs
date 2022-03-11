using FD.ShortUrl.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddControllers();
var configuration = builder.Configuration;
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseOracle(configuration.GetConnectionString("baseDb")));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.MapControllers();

app.Run();