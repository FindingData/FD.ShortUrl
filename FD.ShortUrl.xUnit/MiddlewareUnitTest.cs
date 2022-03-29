using FD.ShortUrl.Api;
using FD.ShortUrl.Api.Controllers;
using FD.ShortUrl.Core;
using FD.ShortUrl.Domain;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FD.ShortUrl.xUnit
{
    public class MiddlewareUnitTest
    {
      


        [Fact]
        public async Task MiddlewareTest_ReturnsNotFoundForRequest()
        {
            using var host = await new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                            services.AddHostedService<SampleHostedService>();
                            services.AddTransient<IOperationTransient, Operation>();
                            services.AddScoped<IOperationScoped, Operation>();
                            services.AddSingleton<IOperationSingleton, Operation>();
                        })
                        .Configure(app =>
                        {
                            app.UseMiddleware<MyMiddleware>();
                        });
                })
                .StartAsync();

            var response = await host.GetTestClient().GetAsync("/");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


        [Fact]
        public async Task TestMiddleware_ExpectedResponse()
        {
            using var host = await new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                            services.AddHostedService<SampleHostedService>();
                            services.AddTransient<IOperationTransient, Operation>();
                            services.AddScoped<IOperationScoped, Operation>();
                            services.AddSingleton<IOperationSingleton, Operation>();
                        })
                        .Configure(app =>
                        {
                            app.UseMiddleware<MyMiddleware>();
                        });
                })
                .StartAsync();

            var server = host.GetTestServer();
            server.BaseAddress = new Uri("https://example.com/A/Path/");

            var context = await server.SendAsync(c =>
            {
                c.Request.Method = HttpMethods.Post;
                c.Request.Path = "/and/file.txt";
                c.Request.QueryString = new QueryString("?and=query");
            });

            Assert.True(context.RequestAborted.CanBeCanceled);
            Assert.Equal(HttpProtocol.Http11, context.Request.Protocol);
            Assert.Equal("POST", context.Request.Method);
            Assert.Equal("https", context.Request.Scheme);
            Assert.Equal("example.com", context.Request.Host.Value);
            Assert.Equal("/A/Path", context.Request.PathBase.Value);
            Assert.Equal("/and/file.txt", context.Request.Path.Value);
            Assert.Equal("?and=query", context.Request.QueryString.Value);
            Assert.NotNull(context.Request.Body);
            Assert.NotNull(context.Request.Headers);
            Assert.NotNull(context.Response.Headers);
            Assert.NotNull(context.Response.Body);
            Assert.Equal(404, context.Response.StatusCode);
            Assert.Null(context.Features.Get<IHttpResponseFeature>().ReasonPhrase);
        }

    }
}