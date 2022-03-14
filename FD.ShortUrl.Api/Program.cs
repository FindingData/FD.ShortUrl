
using FD.ShortUrl.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
 
var app = builder.Build();

app.UseRouting();
app.UseMiddleware<ProductsMiddleware>();
app.MapControllers();
// Approach 2: Routing.
app.MapGet("/Routing", () => "Routing.");
app.Run();