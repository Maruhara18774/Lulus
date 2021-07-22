using Lulus.ViewModels.Products;
using Lulus.ViewModels.Sizes;
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
        public List<ProductViewModel> ListProducts { get; set; } = new List<ProductViewModel>();
        public List<SizeViewModel> ListSizes { get; set; } = new List<SizeViewModel>();
    }
}
