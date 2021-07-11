using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Products.DTOs.Manage
{
    public class UpdatePriceRequest
    {
        public int ProductID { get; set; }

        public double OriginalPrice { get; set; }

        public double SalePrice { get; set; }
    }
}
