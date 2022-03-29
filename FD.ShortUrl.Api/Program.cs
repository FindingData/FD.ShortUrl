using FD.ShortUrl.Api;
using FD.ShortUrl.Core;

await Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
})
    .ConfigureServices(services =>
    {
        services.AddHostedService<SampleHostedService>();
        services.AddTransient<IOperationTransient, Operation>();
        services.AddScoped<IOperationScoped, Operation>();
        services.AddSingleton<IOperationSingleton, Operation>();
    })
    .Build()    
    .RunAsync();

 public partial class Program { }