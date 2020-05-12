using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TestRig.Pages
{
    public class GetModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public GetModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet(string ipAddress)
        {
            ViewData["Message"] = $"{DateTime.UtcNow} [{this.GetType().Name}] OnGet({ipAddress}) Called\r\n";

            string url = ConstructUrl(ipAddress);


            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage {RequestUri = new Uri(url)};
                var response = await client.SendAsync(request);
                ViewData["Message"] += await response.Content.ReadAsStringAsync();
            }
        }

        private string ConstructUrl(string ipAddress)
        {
            return $"http://{ipAddress}/Command";
        }
    }
}
