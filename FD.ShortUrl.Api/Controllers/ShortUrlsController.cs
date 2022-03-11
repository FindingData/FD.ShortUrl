using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FD.ShortUrl.Domain;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.EntityFrameworkCore;

namespace FD.ShortUrl.Api.Controllers
{
    #region snippet_Route
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlsController : ControllerBase
    #endregion
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ShortUrlsController> _logger;

        public ShortUrlsController(ApplicationDbContext context,ILogger<ShortUrlsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/GetItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortUrlPO>>> GetItems()
        {
            var list = _context.ShortUrls.ToList();
            return await _context.ShortUrls.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShortUrlPO>> GetTodoItem(int id)
        {
            ShortUrlPO todoItem;

            using (_logger.BeginScope("using block message"))
            {
                _logger.LogInformation(MyLogEvents.GetItem, "Getting item {Id}", id);

                var todoItems = await _context.ShortUrls.Where(f => f.SHORT_URL_ID == id).ToListAsync();

                if (!todoItems.Any())
                {
                    _logger.LogWarning(MyLogEvents.GetItemNotFound,
                        "Get({Id}) NOT FOUND", id);
                    return NotFound();
                }
                todoItem = todoItems.First();
            }


            return todoItem;
        }


        //[HttpGet("{id}")]
        //public async Task<ActionResult<ShortUrlPO>> GetTodoItem(int id)
        //{
        //    _logger.LogInformation(MyLogEvents.GetItem, "Getting item {Id}", id);

        //    var todoItem = await _context.ShortUrls.Where(f=>f.SHORT_URL_ID == id).ToListAsync();

        //    if (!todoItem.Any())
        //    {
        //        _logger.LogWarning(MyLogEvents.GetItemNotFound, "Get({Id}) NOT FOUND", id);
        //        return NotFound();
        //    }

        //    var routeInfo = ControllerContext.ToCtxString(id);
        //    _logger.LogInformation(MyLogEvents.TestItem, routeInfo);

        //    try
        //    {
        //        if (id == 3885)
        //        {
        //            throw new Exception("Test exception");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogWarning(MyLogEvents.GetItemNotFound, ex, "TestExp({Id})", id);
        //        return NotFound();
        //    }


        //    return todoItem.First();
        //}

    }
}
