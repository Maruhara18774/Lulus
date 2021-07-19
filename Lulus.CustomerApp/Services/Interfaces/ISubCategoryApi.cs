using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lulus.ViewModels.SubCategories;

namespace Lulus.CustomerApp.Services.Interfaces
{
    public interface ISubCategoryApi
    {
        Task<List<SubCateViewModel>> GetList(GetAllSubCategoriesByCategoryIDRequest request);
    }
}
