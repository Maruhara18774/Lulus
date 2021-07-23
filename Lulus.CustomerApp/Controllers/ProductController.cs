using Lulus.CustomerApp.Services.Interfaces;
using Lulus.ViewModels.SubCategories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lulus.CustomerApp.Models.Products;
using Lulus.BAL.Catalog.Products.DTOs.Public;
using Lulus.ViewModels.Products;

namespace Lulus.CustomerApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISubCategoryApi _subCategoryApi;
        private readonly IConfiguration _configuration;
        private readonly IProductApi _productApi;
        public ProductController(ISubCategoryApi subCategoryApi, IConfiguration configuration,IProductApi productApi)
        {
            _subCategoryApi = subCategoryApi;
            _configuration = configuration;
            _productApi = productApi;
        }
        public async Task<IActionResult> Index(int id, int key, int page)
        {
            // Get list sub categories
            ViewBag.Key = id;
            var cateList = await _subCategoryApi.GetList(new GetAllSubCategoriesByCategoryIDRequest(id));

            // Get list products
            var product = new List<ProductViewModel>();
            if (page == 0) page = 1;
            if(key == 0)
            {
                product = await _productApi.GetListByCateID(new GetProductPagingRequest(id, page, 10));
            }
            else
            {
                product = await _productApi.GetListBySubCateID(new GetProductPagingRequest(key, page, 10));
            }

            // Create a view model
            var model = new ProductCategoryModel();
            model.ListSubCategories = cateList;
            var cateSelected = model.ListSubCategories.Find(x => x.ID == key);
            if (cateSelected!= null)
            {
                cateSelected.Checked = true;
            }
            model.ListProducts = product;
            foreach (var p in product)
            {
                foreach(var line in p.ListProductLines)
                {
                    foreach(var size in line.ListSizes)
                    {
                        if(model.ListSizes.Find(x=> x.ID == size.ID) == null)
                        {
                            model.ListSizes.Add(size);
                        }
                    }
                }
            }
                return View(model);
        }
        public IActionResult FullList(int id)
        {
            return RedirectToAction("Index", new { id = id });
        }
        [HttpGet]
        public IActionResult Sort(List<ProductViewModel> model)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sort(SortModel model)
        {
            return PartialView();
        }
        public async Task<IActionResult> Details(int id, int line)
        {
            var detail = await _productApi.GetDetailByID(new GetProductDetailRequest(id));
            if (line == 0) line = 1;
            return View(detail);
        }
    }
}
