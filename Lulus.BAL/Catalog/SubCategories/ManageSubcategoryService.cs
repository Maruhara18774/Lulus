﻿using Lulus.BAL.Catalog.SubCategories.Interfaces;
using Lulus.Data.EF;
using Lulus.ViewModels.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lulus.Data.Entities;

namespace Lulus.BAL.Catalog.SubCategories
{
    public class ManageSubcategoryService : IManageSubcategoryService
    {
        private readonly LulusDBContext _context;
        public ManageSubcategoryService(LulusDBContext context)
        {
            _context = context;
        }
        public async Task<int> CreateSubCategory(CreateSubCategoryRequest request)
        {
            var subcate = new SubCategory()
            {
                Category_ID = request.CategoryID,
                SubCategory_Name = request.Name
            };
            _context.SubCategories.Add(subcate);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteSubCategory(int id)
        {
            var subcate = await _context.SubCategories.FindAsync(id);
            if (subcate == null) return false;
            _context.SubCategories.Remove(subcate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> EditSubCategory(CreateSubCategoryRequest request)
        {
            var subcate = await _context.SubCategories.FindAsync(request.CategoryID);
            if (subcate == null) return 0;
            subcate.Category_ID = request.CategoryID;
            subcate.SubCategory_Name = request.Name;
            return await _context.SaveChangesAsync();
        }
    }
}