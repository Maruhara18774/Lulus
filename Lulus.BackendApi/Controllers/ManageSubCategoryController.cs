﻿using Lulus.BAL.Catalog.SubCategories.Interfaces;
using Lulus.ViewModels.SubCategories;
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
    public class ManageSubCategoryController : Controller
    {
        public readonly IManageSubcategoryService _manageSubcategoryService;
        public ManageSubCategoryController(IManageSubcategoryService manageSubcategoryService)
        {
            _manageSubcategoryService = manageSubcategoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(CreateSubCategoryRequest request)
        {
            var result = await _manageSubcategoryService.CreateSubCategory(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSubCategory(int subCategoryID)
        {
            var result = await _manageSubcategoryService.DeleteSubCategory(subCategoryID);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> EditSubCategory(CreateSubCategoryRequest request)
        {
            var result = await _manageSubcategoryService.EditSubCategory(request);
            return Ok(result);
        }
    }
}