using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Prime.Services;

namespace Prime.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PrimeController : ControllerBase
    {

        private readonly ILogger<PrimeController> _logger;

        private readonly PrimeService _service;

        public PrimeController(ILogger<PrimeController> logger, PrimeService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<int>> Fetch([FromQuery] int after = 1, [FromQuery] int limit = 100)
        {
           if (limit < 1) return BadRequest("Limit must be at least 1");
           return Ok(_service.GetPrimes(after).Take(limit));
        }

        [HttpGet("{candidate}")]
        public bool Check (int candidate) {
            return _service.IsPrime(candidate);
        }

        [HttpGet("{after}")]
        public int Next (int after) {
            return _service.NextPrime(after);
        }
    }
}
