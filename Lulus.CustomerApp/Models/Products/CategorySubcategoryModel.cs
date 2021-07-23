using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Models.Products
{
    public class CategorySubcategoryModel
    {
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public CategorySubcategoryModel() { }
        public CategorySubcategoryModel(int cateID, int subcateID)
        {
            this.CategoryID = cateID;
            this.SubCategoryID = subcateID;
        }
    }
}
