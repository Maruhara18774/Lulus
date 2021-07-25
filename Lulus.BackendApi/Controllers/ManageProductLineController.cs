using Lulus.BAL.Catalog.ProductLines.Interfaces;
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
        public IActionResult Index()
        {
            return View();
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
    }
}
