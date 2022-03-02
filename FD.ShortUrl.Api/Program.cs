
var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(5));

var app = builder.Build();


app.MapGet("/", () => "hello,world");

app.MapGet("/stop", () => app.StopAsync());

await app.RunAsync();