﻿using Lulus.ViewModels.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.SubCategories.Interfaces
{
    public interface IManageSubcategoryService
    {
        Task<int> CreateSubCategory(CreateSubCategoryRequest request);
        Task<int> EditSubCategory(CreateSubCategoryRequest request);
        Task<bool> DeleteSubCategory(int id);
    }
}
