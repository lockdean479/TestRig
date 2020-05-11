using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestRigApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> _logger;

        public CommandController(ILogger<CommandController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation($"[{this.GetType().Name}] Get called");

           StringBuilder builder = new StringBuilder();

           builder.Append($"{DateTime.UtcNow} [{this.GetType().Name}] Get called\r\n");

           return builder.ToString();
        }
    }
}