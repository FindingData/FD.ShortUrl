//using Microsoft.EntityFrameworkCore;
using FD.ShortUrl.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<PositionOption>(options =>
{
    options.Title = "title in delegate";
    options.Name = "Value configured in delegate";
    options.Value = 500;
});

var app = builder.Build();
app.MapControllers();
await app.RunAsync();