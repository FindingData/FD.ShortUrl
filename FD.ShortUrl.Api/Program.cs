using FD.ShortUrl.Api;
using FD.ShortUrl.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
//{
//    options.SuppressModelStateInvalidFilter = true;
//}); ;

var configuration = builder.Configuration;
builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
}).AddNewtonsoftJson();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseOracle(configuration.GetConnectionString("baseDb")));
//builder.Services.AddDbContext<TodoDb>(opt =>
//opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //mvc

app.Run();