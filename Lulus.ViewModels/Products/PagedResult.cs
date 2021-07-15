
using Lulus.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.Products
{
    public class PagedResult<T>: PagedResultBase
    {
        public List<T> Items { set; get; }
    }
}
