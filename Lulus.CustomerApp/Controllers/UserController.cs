using Lulus.CustomerApp.Services.Interfaces;
using Lulus.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApi _userApi;
        public UserController(IUserApi userApi)
        {
            _userApi = userApi;
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
            if (!ModelState.IsValid)
                return View("CustomError");
            var token = await _userApi.Login(request);
            return PartialView("Logged");
        }
    }
}
