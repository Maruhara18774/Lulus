using Lulus.BAL.Catalog.SubCategories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lulus.ViewModels.SubCategories;
using Microsoft.AspNetCore.Authorization;

namespace Lulus.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }
        [HttpPost("GetList")]
        [AllowAnonymous]
        public async Task<IActionResult> GetList(GetAllSubCategoriesByCategoryIDRequest request)
        {
            var lsSubCate = await _subCategoryService.GetAllSubCategoriesByCategoryID(request);
            return Ok(lsSubCate);
        }
    }
}
