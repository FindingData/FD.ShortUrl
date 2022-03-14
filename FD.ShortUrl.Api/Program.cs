
using FD.ShortUrl.Api;

var builder = WebApplication.CreateBuilder(args);



var app = builder.Build();
 

app.UseRouting();

// Approach 2: Routing.
app.MapGet("/Routing", () => "Routing.");
app.Run();