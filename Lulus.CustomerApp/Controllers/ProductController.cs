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
using Lulus.ViewModels.Feedbacks;
using System.Security.Claims;

namespace Lulus.CustomerApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISubCategoryApi _subCategoryApi;
        private readonly IConfiguration _configuration;
        private readonly IProductApi _productApi;
        private readonly IFeedbackApi _feedbackApi;
        public ProductController(ISubCategoryApi subCategoryApi, IConfiguration configuration,IProductApi productApi, IFeedbackApi feedbackApi)
        {
            _subCategoryApi = subCategoryApi;
            _configuration = configuration;
            _productApi = productApi;
            _feedbackApi = feedbackApi;
        }
        public async Task<IActionResult> Index(int id, int key, int page, float min, float max)
        {
            // Get list sub categories
            ViewBag.CateID = id;
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
            ViewBag.SubcateID = key;
            // Create a view model
            var model = new ProductCategoryModel();
            model.ListSubCategories = cateList;
            var cateSelected = model.ListSubCategories.Find(x => x.ID == key);
            if (cateSelected!= null)
            {
                cateSelected.Checked = true;
            }
            model.ListProducts = product;
            if(min != 0 && max != 0)
            {
                model.ListProducts = model.ListProducts.Where(x => x.SalePrice >= min && x.SalePrice <= max).ToList();
            }
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
        [HttpPost]
        public IActionResult Sort(SortModel model)
        {
            return RedirectToAction("Index", new { id = model.CategoryID, key = model.SubcategoryID, min = model.Min, max = model.Max }) ;
        }
        public async Task<IActionResult> Details(int id, int line)
        {
            var detail = await _productApi.GetDetailByID(new GetProductDetailRequest(id));
            if (line == 0)
            {
                line = detail.ListProductLines[0].ID;
            }
            var product = new DetailProductModel()
            {
                ID = detail.ID,
                Name = detail.Name,
                Price = detail.Price,
                SalePrice = detail.SalePrice,
                Description = detail.Description,
                Status = detail.Status,
                ListProductLines = detail.ListProductLines,
                ListFeedbacks = detail.ListFeedbacks,
                CurrentLine = line
            };
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Rating(CreateFeedbackRequest request)
        {
            if(request.Title == null || request.Title == "")
            {
                ViewBag.Error = "Please input title.";
                return PartialView();
            }
            var result = await _feedbackApi.CreateFeedback(request);
            if (result)
            {
                return RedirectToAction("Index", new { id = request.ProductID });
            }
            ViewBag.Error = "Connection error.";
            return PartialView();
        }
    }
}
