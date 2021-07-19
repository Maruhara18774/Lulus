using Lulus.ViewModels.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Models.Products
{
    public class ProductCategoryModel
    {
        public List<SubCateViewModel> ListSubCategories { get; set; } = new List<SubCateViewModel>();
    }
}
