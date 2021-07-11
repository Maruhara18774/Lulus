
using Lulus.BAL.Catalog.Products.DTOs.Manage;
using Lulus.BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Products.Interfaces
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productID);

        Task<List<ProductViewModel>> GetAll();

        Task<PagedViewModel<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}
