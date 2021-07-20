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
            ViewBag.Key = id;
            var requestCate = new GetAllSubCategoriesByCategoryIDRequest();
            requestCate.CategoryID = id;
            var cateList = await _subCategoryApi.GetList(requestCate);

            var requestProduct = new GetProductPagingRequest();
            if (page == 0) page = 1;
            requestProduct.PageIndex = page;
            requestProduct.PageSize = 10;
            requestProduct.ID = id;
            var product = await _productApi.GetListByCateID(requestProduct);

            var model = new ProductCategoryModel();
            model.ListSubCategories = cateList;
            var cateSelected = model.ListSubCategories.Find(x => x.ID == key);
            if (cateSelected!= null)
            {
                cateSelected.Checked = true;
            }
            model.ListProducts = product;
            return View(model);
        }
        public IActionResult FullList(int id)
        {
            return RedirectToAction("Index", new { id = id });
        }
    }
}
