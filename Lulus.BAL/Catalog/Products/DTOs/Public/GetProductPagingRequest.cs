﻿using Lulus.BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Products.DTOs.Public
{
    public class GetProductPagingRequest: PagingRequestBase
    {
        public int SubCateId { get; set; }
    }
}
