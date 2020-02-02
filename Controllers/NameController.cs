using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NameApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NameController : ControllerBase
    {
        private readonly ILogger<NameController> _logger;

        public NameController(ILogger<NameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> GetAsync()
        {
            var host = Environment.GetEnvironmentVariable("NAME_API_SERVICE_HOST");
            var port = Environment.GetEnvironmentVariable("NAME_API_SERVICE_PORT");
            if (string.IsNullOrEmpty(host)) return await Task.FromResult("empty");
            return await Task.FromResult(host+":"+port);
        }
    }
}
