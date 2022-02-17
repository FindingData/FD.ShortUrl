
using FD.ShortUrl.Api;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseOracle(configuration.GetConnectionString("baseDb")));
// Configure JSON options.
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = new UpperCaseNamingPolicy();
    options.SerializerOptions.WriteIndented = true;
});
builder.Services.AddMvcCore().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = new UpperCaseNamingPolicy();
    options.JsonSerializerOptions.WriteIndented = true;
});

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
 
app.Run();

