using Lulus.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class Product
    {
        public int Product_ID { get; set; }

        public string Product_Name { get; set; }

        public double Product_Price { get; set; }
        public double Product_SalePrice { get; set; }

        public string Product_Description { get; set; }

        public int SubCategory_ID { get; set; }

        public ProductStatus Status { get; set; }

        public virtual List<Feedback> Feedbacks { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public virtual List<ProductLine> ProductLines { get; set; }
    }
}
