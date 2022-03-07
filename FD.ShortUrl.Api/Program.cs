var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureDefaults(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
await app.RunAsync();