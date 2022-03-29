using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Test
{
    public class CustomWebApplicationFactory<Program>
     : WebApplicationFactory<Program> where Program : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<TodoDb>));

                services.Remove(descriptor);

                services.AddDbContext<TodoDb>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });
                //if use SqlServer
                //services.AddDbContext<ApplicationDbContext>((options, context) =>
                //{
                //    context.UseSqlServer(
                //        Configuration.GetConnectionString("TestingDbConnectionString"));
                //});

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<TodoDb>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<Program>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                            "database with test messages. Error: {Message}", ex.Message);
                    }
                }
            });
        }
    }
}
