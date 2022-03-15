
using FD.ShortUrl.Api;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => { 
 options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
});

 
builder.Services.AddRouting(options =>
    options.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer));

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller:slugify=Home}/{action:slugify=Index}/{id?}");

app.MapControllers();

app.Run();