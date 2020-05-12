using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TestRig.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            ViewData["Message"] = $"{DateTime.UtcNow} [{this.GetType().Name}] OnGet Called\r\n";
        }

        public async Task<IActionResult> OnPostAsync(string ipAddress)
        {
            ViewData["Message"] = $"{DateTime.UtcNow} [{this.GetType().Name}] OnPostASync({ipAddress}) Called\r\n";
            
            return new RedirectToPageResult("Get", new { ipAddress = ipAddress });
        }




    }
}
