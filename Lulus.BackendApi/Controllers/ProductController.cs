using Lulus.BAL.Catalog.Products.DTOs.Public;
using Lulus.BAL.Catalog.Products.Interfaces;
using Lulus.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.BackendApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> GetByCateID(GetProductPagingRequest request)
        {
            var result = await _productService.GetAllByCateID(request);
            foreach (var product in result)
            {
                foreach (var line in product.ListProductLines)
                {
                    line.Texture_Image_Url = "https://localhost:44354"+line.Texture_Image_Url;
                    foreach(var image in line.ListImages)
                    {
                        image.Image_Url = "https://localhost:44354" + image.Image_Url;
                    }
                }
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> GetBySubCateID(GetProductPagingRequest request)
        {
            var result = await _productService.GetAllBySubCateID(request);
            foreach (var product in result)
            {
                foreach (var line in product.ListProductLines)
                {
                    line.Texture_Image_Url = "https://localhost:44354" + line.Texture_Image_Url;
                    foreach (var image in line.ListImages)
                    {
                        image.Image_Url = "https://localhost:44354" + image.Image_Url;
                    }
                }
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> GetDetailByID(GetProductDetailRequest request)
        {
            var result = await _productService.GetDetailByID(request);

            foreach (var line in result.ListProductLines)
            {
                line.Texture_Image_Url = "https://localhost:44354" + line.Texture_Image_Url;
                foreach (var image in line.ListImages)
                {
                    image.Image_Url = "https://localhost:44354" + image.Image_Url;
                }
            }
            return Ok(result);
        }
    }
}
