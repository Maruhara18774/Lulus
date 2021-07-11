﻿using Lulus.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Products.DTOs
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
        public double SalePrice { get; set; }

        public string Description { get; set; }

        public int SubCategory_ID { get; set; }

        public ProductStatus Status { get; set; }
    }
}
