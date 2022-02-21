using FD.ShortUrl.Api;
using FD.ShortUrl.Core;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services
    .AddConfig(builder.Configuration)
    .AddMyDependencyGroup();
builder.Services.AddHostedService<NormalHostedService>();
var app = builder.Build();
app.MapControllers();
Console.WriteLine(app.Configuration["PositionOptions:Title"]);

app.Run();