
using FD.ShortUrl.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<PositionOption>(
    builder.Configuration.GetSection("PositionOptions"));

var app = builder.Build();
app.MapControllers();
await app.RunAsync();