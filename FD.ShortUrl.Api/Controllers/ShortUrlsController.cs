using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FD.ShortUrl.Domain;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ShortUrlsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GetItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortUrlPO>>> GetItems()
        {
            var list = _context.ShortUrls.ToList();
            return await _context.ShortUrls.ToListAsync();
        }

       
    }
}
