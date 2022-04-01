using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FD.ShortUrl.Api.Pages
{
    [Authorize]
    public class SecurePageModel : PageModel
    {
        private readonly ILogger<SecurePageModel> _logger;

        public SecurePageModel(ILogger<SecurePageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
