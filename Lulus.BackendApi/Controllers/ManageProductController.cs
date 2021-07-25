using Lulus.BAL.Catalog.Products.Interfaces;
using Lulus.ViewModels.Products.Manage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.BackendApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ManageProductController : Controller
    {
        private readonly IManageProductService _manageProductService;
        public ManageProductController(IManageProductService manageProductService)
        {
            _manageProductService = manageProductService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            var result = await _manageProductService.Create(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int productID)
        {
            var result = await _manageProductService.Delete(productID);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateRequest request)
        {
            var result = await _manageProductService.Update(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePrice(UpdatePriceRequest request)
        {
            var result = await _manageProductService.UpdatePrice(request);
            return Ok(result);
        }
    }
}
