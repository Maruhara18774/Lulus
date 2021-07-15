
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.Products.Manage
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public double SalePrice { get; set; }

        public string Description { get; set; }

        public int SubCategoryID { get; set; }
    }
}
