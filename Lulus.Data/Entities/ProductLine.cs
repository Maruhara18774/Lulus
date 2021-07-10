using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class ProductLine
    {
        public int ProductLine_ID { get; set; }

        public string Texture_Name { get; set; }

        public string Texture_Image { get; set; }

        public DateTime ProductLine_CreatedDate { get; set; }

        public DateTime ProductLine_UpdatedDate { get; set; }

        public int Product_ID { get; set; }

        public virtual List<LineQuantity> LineQuantities { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual Product Product { get; set; }
    }
}
