using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.LineQuantity
{
    public class UpdateQuantityRequest
    {
        public int LineQuantityID { get; set; }
        public int Quantity { get; set; }
    }
}
