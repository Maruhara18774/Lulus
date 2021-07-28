using Lulus.BAL.Catalog.Users.Interfaces;
using Lulus.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.Login(request);
            if(resultToken == "Wrong username" || resultToken == "Wrong password")
            {
                return BadRequest(resultToken);
            }
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Login failed.");
            }
            return Ok(resultToken);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Register(request);
            if (!result)
            {
                return BadRequest(false);
            }
            return Ok(true);
        }
        [HttpPost("AdminLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> AdminLogin([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.AdminLogin(request);
            if (resultToken == "Wrong username" || resultToken == "Wrong password")
            {
                return BadRequest(resultToken);
            }
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Login failed.");
            }
            return Ok(resultToken);
        }
    }
}
