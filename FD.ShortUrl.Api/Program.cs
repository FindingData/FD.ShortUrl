
using FD.ShortUrl.Api;
using FD.ShortUrl.Core;
using FD.ShortUrl.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Polly;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvcCore().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = new UpperCaseNamingPolicy();
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseOracle(builder.Configuration.GetConnectionString("baseDb")));
builder.Services.AddTransient<ValidateHeaderHandler>();

builder.Services.AddHttpClient("PropagateHeaders", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://localhost:3302/");
    // using Microsoft.Net.Http.Headers;
    // The GitHub API requires two headers.
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, " application/json");
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "HttpRequestsSample");
})
    .AddHeaderPropagation();

builder.Services.AddHeaderPropagation(options =>
{
    options.Headers.Add("X-TraceId");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseHeaderPropagation();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //mvc
app.Run();