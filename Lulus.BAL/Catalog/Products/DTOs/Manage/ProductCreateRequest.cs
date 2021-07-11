using Lulus.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Products.DTOs.Manage
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
