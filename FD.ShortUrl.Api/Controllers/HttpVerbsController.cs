using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace FD.ShortUrl.Api.Controllers
{
    public class HttpVerbsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpVerbsController(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;



        public IActionResult Index()
        {
            return View();
        }
        public async Task Post()
        {
            var item = new ShortUrlPO()
            {
                CREATED_BY = 1,
                URL = "https://www.baidu.com/",
                 SHORT_CODE = "aefca"
            };
            var itemJson = new StringContent(
                JsonSerializer.Serialize(item),
                Encoding.UTF8,
                Application.Json); // using static System.Net.Mime.MediaTypeNames;
            var httpClient = _httpClientFactory.CreateClient();
            using var httpResponseMessage =
                await httpClient.PostAsync("/api/ShortUrls", itemJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }


    }
}
