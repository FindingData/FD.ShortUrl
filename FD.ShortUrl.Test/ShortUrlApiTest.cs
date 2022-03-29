using FD.ShortUrl.Api;
using FD.ShortUrl.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Threading.Tasks;
using Xunit;

namespace FD.ShortUrl.Test
{
    public class ShortUrlApiTest
    {
        [Fact]
        public async Task HelloWorldTest()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(webBuilder =>
                {
                     
                });

            var client = application.CreateClient();
           
        }
    }
}