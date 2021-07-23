using Lulus.BAL.Catalog.Products.DTOs.Public;
using Lulus.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Products.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllByCateID(GetProductPagingRequest request);
        Task<List<ProductViewModel>> GetAllBySubCateID(GetProductPagingRequest request);

        Task<ProductViewModel> GetDetailByID(GetProductDetailRequest request);
    }
}
