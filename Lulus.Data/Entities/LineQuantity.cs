using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class LineQuantity
    {
        [Key]
        public int LineQuantity_ID { get; set; }

        public int ProductLine_ID { get; set; }

        public int Size_ID { get; set; }

        public int Quantity { get; set; }

    }
}
