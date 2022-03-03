
using FD.ShortUrl.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddConfig(builder.Configuration)
    .Configure<PositionOption>(
    builder.Configuration.GetSection(PositionOption.PositionOptions));

var app = builder.Build();
app.MapControllers();
 
await app.RunAsync();