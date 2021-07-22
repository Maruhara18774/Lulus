using Lulus.BAL.Catalog.Products.DTOs.Public;
using Lulus.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Services.Interfaces
{
    public interface IProductApi
    {
        Task<List<ProductViewModel>> GetListByCateID(GetProductPagingRequest request);
        Task<List<ProductViewModel>> GetListBySubCateID(GetProductPagingRequest request);
    }
}
