using FD.ShortUrl.Api;
using FD.ShortUrl.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<Service1>();
builder.Services.AddSingleton<Service2>();
var myKey = builder.Configuration["MyKey"];
builder.Services.AddSingleton<IService3>(sp => new Service3(myKey));

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();