
using Lulus.BAL.Catalog.Categories.Interfaces;
using Lulus.Data.EF;
using Lulus.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly LulusDBContext _context;
        public CategoryService(LulusDBContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryViewModel>> GetAllCategory()
        {
            var query = from c in _context.Categories
                        select c;
            var data = await query.Select(
                p => new CategoryViewModel()
                {
                    ID = p.Category_ID,
                    Name = p.Category_Name
                }).ToListAsync();
            return data;
        }
    }
}
