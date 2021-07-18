using Lulus.ViewModels.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.SubCategories.Interfaces
{
    public interface ISubCategoryService
    {
        Task<List<SubCateViewModel>> GetAllSubCategoriesByCategoryID(GetAllSubCategoriesByCategoryIDRequest request);
    }
}
