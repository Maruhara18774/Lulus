using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class Size
    {
        public int Size_ID { get; set; }

        public string Size_Key { get; set; }

        public virtual List<LineQuantity> LineQuantities { get; set; }
    }
}
