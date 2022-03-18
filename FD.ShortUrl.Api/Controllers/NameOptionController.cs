using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameOptionController : ControllerBase
    {
        private readonly TopItemSettings _monthTopItem;
        private readonly TopItemSettings _yearTopItem;

        public NameOptionController(IOptionsSnapshot<TopItemSettings> namedOptionsAccessor)
        {
            _monthTopItem = namedOptionsAccessor.Get(TopItemSettings.Month);
            _yearTopItem = namedOptionsAccessor.Get(TopItemSettings.Year);
        }
        [HttpGet]
        public ContentResult Index()
        {
            return Content($"Month:Name {_monthTopItem.Name} \n" +
                      $"Month:Model {_monthTopItem.Model} \n\n" +
                      $"Year:Name {_yearTopItem.Name} \n" +
                      $"Year:Model {_yearTopItem.Model} \n");
        }
    }
}
