using Lulus.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }

        [MaxLength(100)]
        public string Product_Name { get; set; }

        public double Product_Price { get; set; }
        public double? Product_SalePrice { get; set; }

        public string Product_Description { get; set; }

        public int? Category_ID { get; set; }

        public ProductStatus Status { get; set; }
    }
}
