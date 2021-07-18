using Lulus.BAL.Catalog.SubCategories.Interfaces;
using Lulus.Data.EF;
using Lulus.ViewModels.SubCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.SubCategories
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly LulusDBContext _context;
        public SubCategoryService(LulusDBContext context)
        {
            _context = context;
        }
        public async Task<List<SubCateViewModel>> GetAllSubCategoriesByCategoryID(GetAllSubCategoriesByCategoryIDRequest request)
        {
            var query = from c in _context.SubCategories
                        where c.Category_ID == request.CategoryID
                        select c;
            var data = await query.Select(c => new SubCateViewModel()
            {
                ID = c.SubCategory_ID,
                Name = c.SubCategory_Name
            }).ToListAsync();
            return data;
        }
    }
}
