using Lulus.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class Order
    {
        public int Order_ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public double Order_Total { get; set; }

        public string User_ID { get; set; }

        public OrderStatus Status { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }

        public virtual User User { get; set; }


    }
}
