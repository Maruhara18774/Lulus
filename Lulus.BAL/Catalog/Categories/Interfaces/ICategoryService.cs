using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lulus.BAL.Catalog.Categories.DTOs;

namespace Lulus.BAL.Catalog.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategory();
    }
}
