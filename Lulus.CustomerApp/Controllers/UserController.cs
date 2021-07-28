using Lulus.CustomerApp.Services.Interfaces;
using Lulus.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lulus.Data.Entities;
using System.Security.Claims;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Lulus.CustomerApp.Models.Users;

namespace Lulus.CustomerApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApi _userApi;
        private readonly IConfiguration _configuration;
        public UserController(IUserApi userApi, IConfiguration configuration)
        {
            _userApi = userApi;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var token = await _userApi.Login(request);
            var userPrinciple = ValidateToken(token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };
            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrinciple,
                        authProperties);
            

            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult LoginStrict()
        {
            return View();
        }
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CustomRegister register)
        {
            if(register.Password != register.ConfirmPassword)
            {
                ViewBag.Log = "Confirm password was wrong.";
                return View(register);
            }
            var request = new RegisterRequest()
            {
                Email = register.Email,
                Username = register.Username,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Password = register.Password
            };
            var result = await _userApi.Register(request);
            if (result)
            {
                ViewBag.Log = "Success. Now, you can use it to login.";
                return View(new CustomRegister());
            }
            ViewBag.Log = "Something was wrong.";
            return View(register);
        }
    }
}
