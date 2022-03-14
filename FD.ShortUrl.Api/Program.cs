
using FD.ShortUrl.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

 
builder.Services.AddRouting(options =>
    options.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer));

var app = builder.Build();
  
app.MapControllers();

app.Run();