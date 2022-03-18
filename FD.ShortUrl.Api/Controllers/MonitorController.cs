using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        private readonly IOptionsMonitor<PositionOption> _optionsDelegate;

        public MonitorController(IOptionsMonitor<PositionOption> optionsDelegate)
        {
            _optionsDelegate = optionsDelegate;
        }
        [HttpGet]
        public ContentResult Index()
        {
            return Content($"Option1: {_optionsDelegate.CurrentValue.Name} \n" +
                           $"Option2: {_optionsDelegate.CurrentValue.Value}");
        }
    }
}
