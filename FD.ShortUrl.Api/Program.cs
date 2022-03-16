
using FD.ShortUrl.Api;
using FD.ShortUrl.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Refit;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddMvcCore().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = new UpperCaseNamingPolicy();
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseOracle(builder.Configuration.GetConnectionString("baseDb")));
builder.Services.AddTransient<ValidateHeaderHandler>();

builder.Services.AddHttpClient("HttpMessageHandler", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://localhost:3302/");
    // using Microsoft.Net.Http.Headers;
    // The GitHub API requires two headers.
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, " application/json");
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "HttpRequestsSample");
})
    .AddHttpMessageHandler<ValidateHeaderHandler>();

var app = builder.Build();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //mvc
app.Run();