using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.Common
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
        public PagingRequestBase()
        {

        }
        public PagingRequestBase(int pIndex, int pSize)
        {
            this.PageIndex = pIndex;
            this.PageSize = pSize;
        }
    }
}
