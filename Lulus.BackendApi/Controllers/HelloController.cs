using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.BackendApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HelloController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello world!");
        }
        [HttpPost]
        public IActionResult WelcomeYou(string name)
        {
            return Ok("Hello "+name+" !");
        }
        [HttpGet]
        public IActionResult GetConnectionString()
        {
            return Ok(_configuration.GetConnectionString("LulusDatabase"));
        }
    }
}
