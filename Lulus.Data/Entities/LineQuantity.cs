using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lulus.Data.Entities;

namespace Lulus.Data.Entities
{
    public class LineQuantity
    {
        public int LineQuantity_ID { get; set; }

        public int ProductLine_ID { get; set; }

        public virtual ProductLine ProductLine { get; set; }

        public int Size_ID { get; set; }

        public virtual Size Size { get; set; }

        public int Quantity { get; set; }

    }
}
