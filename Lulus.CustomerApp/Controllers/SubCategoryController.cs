using Lulus.CustomerApp.Services.Interfaces;
using Lulus.ViewModels.SubCategories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryApi _subCategoryApi;
        private readonly IConfiguration _configuration;
        public SubCategoryController(ISubCategoryApi subCategoryApi, IConfiguration configuration)
        {
            _subCategoryApi = subCategoryApi;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            string key = RouteData.Values["id"].ToString();
            return View();
        }
    }
}
