using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            string key = RouteData.Values["id"].ToString();
            return View();
        }
        public Task<IActionResult> GetSubCate(int cateId)
        {

        }
    }
}
