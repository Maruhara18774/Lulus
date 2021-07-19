using Lulus.CustomerApp.Services.Interfaces;
using Lulus.ViewModels.SubCategories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lulus.CustomerApp.Models.Products;

namespace Lulus.CustomerApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISubCategoryApi _subCategoryApi;
        private readonly IConfiguration _configuration;
        public ProductController(ISubCategoryApi subCategoryApi, IConfiguration configuration)
        {
            _subCategoryApi = subCategoryApi;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            int key = int.Parse(RouteData.Values["id"].ToString());
            ViewBag.Key = key;
            var request = new GetAllSubCategoriesByCategoryIDRequest();
            request.CategoryID = key;
            var cateList = await _subCategoryApi.GetList(request);

            var model = new ProductCategoryModel();
            model.ListSubCategories = cateList;
            return View(model);
        }
    }
}
