using Lulus.BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Products.DTOs.Manage
{
    public class GetProductPagingRequest: PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
