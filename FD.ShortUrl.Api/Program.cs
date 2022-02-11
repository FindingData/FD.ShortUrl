var app = WebApplication.Create(args);

// Setup the file server to serve static files.
app.UseFileServer();
app.MapGet("/oops", () =>
{
    throw new InvalidOperationException("Oops, the '/' route has thrown an exception.");
});
app.MapGet("/", () => "Hello World!");
app.Run();