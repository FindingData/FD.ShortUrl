using FD.ShortUrl.Api;
using FD.ShortUrl.Core;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<NormalHostedService>();
var app = builder.Build();

app.Run();