﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("index");
        }

        public IActionResult Bad()
        {
            return BadRequest(ModelState);
        }

        public IActionResult SubIndex()
        {
            return Content("subIndex");
        }

        public IActionResult Subscribe(int i)
        {
            try
            {
                var a = 100 / i;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("参数错误");
            }
            return Content("Subscribe");
        }
    }
}
