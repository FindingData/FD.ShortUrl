
using FD.ShortUrl.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddConfig(builder.Configuration)
    .Configure<PositionOption>(
builder.Configuration.GetSection(PositionOption.PositionOptions));
builder.Configuration.AddEnvironmentVariables();


var app = builder.Build();
Console.WriteLine($"EKey={Environment.GetEnvironmentVariable("EKey")}");
app.MapControllers();
 
await app.RunAsync();