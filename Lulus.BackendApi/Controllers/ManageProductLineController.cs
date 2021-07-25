using Lulus.BAL.Catalog.ProductLines.Interfaces;
using Lulus.ViewModels.LineQuantity;
using Lulus.ViewModels.ProductLines;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    [Authorize]
    public class ManageProductLineController : Controller
    {
        private readonly IManageProductLineService _manageProductLineService;
        private readonly IWebHostEnvironment _environment;
        public ManageProductLineController(IManageProductLineService manageProductLineService, IWebHostEnvironment environment)
        {
            _manageProductLineService = manageProductLineService;
            _environment = environment;
        }
        [HttpPost]
        public async Task<IActionResult> AddImage(AddImageRequest request)
        {
            string uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (request.Image.Length > 0)
            {
                string filePath = Path.Combine(uploads, request.Image.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Image.CopyToAsync(fileStream);
                    fileStream.Close();
                }
                request.ImageUrl = filePath;
                var result = await _manageProductLineService.AddImage(request);
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> AddQuantity(AddQuantityRequest request)
        {
            var result = await _manageProductLineService.AddQuantity(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductLine(CreateProductLineRequest request)
        {
            string uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (request.Texture_Image.Length > 0)
            {
                string filePath = Path.Combine(uploads, request.Texture_Image.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Texture_Image.CopyToAsync(fileStream);
                    fileStream.Close();
                }
                request.Texture_ImageUrl = filePath;
                var result = await _manageProductLineService.CreateProductLine(request);
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteImage(DeleteImageRequest request)
        {
            var result = await _manageProductLineService.DeleteImage(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> GetAllImage(GetAllImageByIDRequest request)
        {
            var result = await _manageProductLineService.GetAllImage(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> GetAllLinesByID(GetAllLinesByIDRequest request)
        {
            var result = await _manageProductLineService.GetAllLinesByID(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductLine(CreateProductLineRequest request)
        {
            var result = await _manageProductLineService.UpdateProductLine(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityRequest request)
        {
            var result = await _manageProductLineService.UpdateQuantity(request);
            return Ok(result);
        }
    }
}
