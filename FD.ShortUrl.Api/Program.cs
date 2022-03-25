using FD.ShortUrl.Api;
using FD.ShortUrl.Core;
using FD.ShortUrl.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, new VcardInputFormatter());
    options.OutputFormatters.Insert(0, new VcardOutputFormatter());    
})
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

//builder.Services.AddDbContext<ApplicationDbContext>(opt =>
//    opt.UseOracle(configuration.GetConnectionString("baseDb")));
builder.Services.AddDbContext<ContactDb>(opt =>
opt.UseInMemoryDatabase("ContactDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //mvc

app.Run();