
using Lulus.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.Products.Manage
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public double SalePrice { get; set; }

        public string Description { get; set; }

        public int SubCategoryID { get; set; }

        public ProductStatus Status { get; set; }
    }
}
