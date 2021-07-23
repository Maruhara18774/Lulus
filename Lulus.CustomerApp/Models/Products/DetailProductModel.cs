using Lulus.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Models.Products
{
    public class DetailProductModel: ProductViewModel
    {
        public int CurrentLine { get; set; }
    }
}
