using Lulus.BAL.Catalog.Products.DTOs.Public;
using Lulus.BAL.Catalog.Products.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            return Ok(result);
        }
    }
}
