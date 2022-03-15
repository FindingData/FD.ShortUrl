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

        public async Task<IActionResult> Post()
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
            
            
            var httpClient = _httpClientFactory.CreateClient("su");
            using var httpResponseMessage =
                await httpClient.PostAsync("/api/ShortUrls", itemJson);

            var result = await httpResponseMessage.Content.ReadAsStringAsync();
            return Ok(result);
        }


        public async Task<IActionResult> Put()
        {
            var item = new ShortUrlPO()
            {
                SHORT_URL_ID = 62,
                CREATED_BY = 1,
                URL = "https://www.qq.com/",
                SHORT_CODE = "aefca"
            };

            
            var httpClient = _httpClientFactory.CreateClient("su");

            var todoItemJson = new StringContent(
               JsonSerializer.Serialize(item),
               Encoding.UTF8,
               Application.Json);

            using var httpResponseMessage =
                await httpClient.PutAsync($"/api/ShortUrls/{item.SHORT_URL_ID}", todoItemJson);
            var result = await httpResponseMessage.Content.ReadAsStringAsync();

            return Ok(result);
        }


        public async Task<IActionResult> Delete()
        {
            var id = 62;
            var httpClient = _httpClientFactory.CreateClient("su");
          
            using var httpResponseMessage =
                await httpClient.DeleteAsync($"/api/ShortUrls/{id}");
            var result = await httpResponseMessage.Content.ReadAsStringAsync();

            return Ok(result);
        }

    }
}
