using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
    [FormatFilter]
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

        //// GET: api/GetItems
        //[HttpGet("sync")]
        //public IEnumerable<ShortUrlPO> GetItems()
        //{
        //    var list = _context.ShortUrls.ToList();
        //    foreach (var item in list)
        //    {
        //        yield return item;
        //    }
        //}

        //[HttpGet]
        //public async IAsyncEnumerable<ShortUrlPO> GetItems()
        //{
        //    var list = _context.ShortUrls;

        //    await foreach (var item in list)
        //    {
        //        yield return item;
        //    }
        //}

    //    [HttpGet("Version")]
    //    public ContentResult GetVersion() =>
    //Content("v1.0.0");


        [HttpGet]
        public IActionResult Get() =>
                    new JsonResult(_context.ShortUrls.ToList(),new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = null
                    });




        [HttpGet("{id}.{format?}")]
        public ShortUrlPO? GetById(int id) =>
    _context.ShortUrls.Where(f=>f.SHORT_URL_ID==id).ToList().FirstOrDefault();


        // GET: api/TodoItems/5
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShortUrlPO))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult GetTodoItem(int id)
        //{
        //    var todoItems =  _context.ShortUrls.Where(f => f.SHORT_URL_ID == id).ToList();

        //    if (!todoItems.Any())
        //    {                
        //        return NotFound();
        //    }          

        //    return Ok(todoItems.First());
        //}


        //[HttpGet("{id}")]
        //public async Task<ActionResult<ShortUrlPO>> GetTodoItem(int id)
        //{
        //    ShortUrlPO todoItem;

        //    using (_logger.BeginScope("using block message"))
        //    {
        //        _logger.LogInformation(MyLogEvents.GetItem, "Getting item {Id}", id);

        //        var todoItems = await _context.ShortUrls.Where(f => f.SHORT_URL_ID == id).ToListAsync();

        //        if (!todoItems.Any())
        //        {
        //            _logger.LogWarning(MyLogEvents.GetItemNotFound,
        //                "Get({Id}) NOT FOUND", id);
        //            return NotFound();
        //        }
        //        todoItem = todoItems.First();
        //    }


        //    return todoItem;
        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<string>> CreateItem(ShortUrlPO shortUrl)
        //{
        //    try
        //    {                               
        //        var entity = _context.ShortUrls.Add(shortUrl);
        //        await _context.SaveChangesAsync();
        //        var result = entity.Entity.SHORT_URL_ID;
        //        var act = nameof(GetTodoItem);
        //        return CreatedAtAction(nameof(GetTodoItem), new { id = result });
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return Content("ok");
        //}

        [HttpPut("{short_url_id}")]
        public async Task<ActionResult<bool>> SaveItem(int short_url_id, [FromBody]ShortUrlPO shortUrl)
        {
            try
            {
                var result = false;
                var list = await _context.ShortUrls.Where(f => f.SHORT_URL_ID == short_url_id).ToListAsync();
                var entity = list.First();
                if (entity != null)
                {
                    entity.URL = shortUrl.URL;
                    entity.SHORT_CODE = shortUrl.SHORT_CODE;
                    entity.CREATED_BY = shortUrl.CREATED_BY;
                    result = (await _context.SaveChangesAsync()) > 0;
                }
                
                return result;
            }
            catch (Exception ex)
            {

            }
            return Content("false");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteItem(int id)
        {
            try
            {             
                var entity = new ShortUrlPO()
                {
                    SHORT_URL_ID = id
                };
                _context.Remove(entity);
                var result = (await _context.SaveChangesAsync()) > 0;

                return result;
            }
            catch (Exception ex)
            {

            }
            return Content("false");

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
