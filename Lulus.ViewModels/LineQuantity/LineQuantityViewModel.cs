using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.LineQuantity
{
    public class LineQuantityViewModel
    {
        public int ID { get; set; }
        public int ProductLineID { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        public string SizeKey { get; set; }
    }
}
