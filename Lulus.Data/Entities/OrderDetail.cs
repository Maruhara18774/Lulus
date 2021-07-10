using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class OrderDetail
    {
        public int OrderDetail_ID { get; set; }

        public int OrderDetail_Quantity { get; set; }

        public double OrderDetail_Total { get; set; }

        public int Order_ID { get; set; }

        public int ProductLine_ID { get; set; }

        public virtual Order Order { get; set; }

        public virtual ProductLine ProductLine { get; set; }
}
}
