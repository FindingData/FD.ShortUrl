
using FD.ShortUrl.Api;
using FD.ShortUrl.Core;
using Microsoft.Net.Http.Headers;
using Polly;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<IOperationScoped, OperationScoped>();

builder.Services.AddTransient<OperationHandler>();
builder.Services.AddTransient<OperationResponseHandler>();

builder.Services.AddHttpClient("PollyWaitAndRetry", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://localhost:3302/");
    // using Microsoft.Net.Http.Headers;
    // The GitHub API requires two headers.
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, " application/json");
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "HttpRequestsSample");
})
    .AddTransientHttpErrorPolicy(policyBuilder =>
        policyBuilder.WaitAndRetryAsync(
            3, retryNumber => TimeSpan.FromMilliseconds(600)));

var app = builder.Build();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //mvc
app.Run();