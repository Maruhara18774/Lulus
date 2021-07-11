using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lulus.BAL.Catalog.Products.DTOs.Public;
using Lulus.BAL.Catalog.Products.DTOs;
using Lulus.BAL.DTOs;

namespace Lulus.BAL.Catalog.Products.Interfaces
{
    public interface IProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllBySubCateID(GetProductPagingRequest request);
    }
}
