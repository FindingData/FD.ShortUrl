using FD.ShortUrl.Api;
using FD.ShortUrl.Core;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, new VcardInputFormatter());
    options.OutputFormatters.Insert(0, new VcardOutputFormatter());
    options.Filters.Add<HttpResponseExceptionFilter>();
}).ConfigureApiBehaviorOptions(options => {
    options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
          "https://httpstatuses.com/404";

    options.InvalidModelStateResponseFactory = context =>
            new BadRequestObjectResult(context.ModelState)
            {
                ContentTypes =
                {
                    // using static System.Net.Mime.MediaTypeNames;
                    Application.Json,
                    Application.Xml
                }
            };
}).AddXmlSerializerFormatters()
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

//builder.Services.AddTransient<ProblemDetailsFactory, SampleProblemDetailsFactory>();

//builder.Services.AddDbContext<ApplicationDbContext>(opt =>
//    opt.UseOracle(configuration.GetConnectionString("baseDb")));
builder.Services.AddDbContext<ContactDb>(opt =>
opt.UseInMemoryDatabase("ContactDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/error-development");
//}
//else
//{
//    app.UseExceptionHandler("/error");
//}

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //mvc

app.Run();