using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.LineQuantity
{
    public class AddQuantityRequest
    {
        public int ID { get; set; }
        public int ProductLineID { get; set; }

        public int Size_ID { get; set; }

        public int Quantity { get; set; }
    }
}
