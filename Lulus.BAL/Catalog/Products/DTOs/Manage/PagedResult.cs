using Lulus.BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Products.DTOs.Manage
{
    public class PagedResult<T>: PagedResultBase
    {
        public List<T> Items { set; get; }
    }
}
