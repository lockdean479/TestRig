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

            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://testrigapi/Command");
                var response = await client.SendAsync(request);
                ViewData["Message"] += await response.Content.ReadAsStringAsync();
            }
        }



    }
}
