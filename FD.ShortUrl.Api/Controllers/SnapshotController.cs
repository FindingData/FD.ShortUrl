using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnapshotController : ControllerBase
    {
        private readonly PositionOption _options;

        public SnapshotController(IOptionsSnapshot<PositionOption> snapshotOptionsAccessor)
        {
            _options = snapshotOptionsAccessor.Value;
        }

        public ContentResult Index()
        {
            return Content($"Name: {_options.Name} \n" +
                           $"Value: {_options.Value}");
        }
    }
}
