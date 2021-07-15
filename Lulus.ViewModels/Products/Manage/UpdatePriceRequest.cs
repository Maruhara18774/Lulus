using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.Products.Manage
{
    public class UpdatePriceRequest
    {
        public int ProductID { get; set; }

        public double OriginalPrice { get; set; }

        public double SalePrice { get; set; }
    }
}
