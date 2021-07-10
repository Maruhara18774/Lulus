using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetail_ID { get; set; }

        [Range(minimum: 0, maximum: int.MaxValue)]
        public int OrderDetail_Quantity { get; set; }

        [Range(minimum: 0, maximum: double.MaxValue)]
        public double OrderDetail_Total { get; set; }

        public int Order_ID { get; set; }

        public int ProductLine_ID { get; set; }

    }
}
