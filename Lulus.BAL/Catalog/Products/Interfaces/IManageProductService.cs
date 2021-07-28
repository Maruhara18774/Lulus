
using Lulus.ViewModels.Common;
using Lulus.ViewModels.Products;
using Lulus.ViewModels.Products.Manage;
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

        Task<bool> UpdatePrice(UpdatePriceRequest request);
        Task<List<ProductViewModel>> GetAllProduct(PagingRequestBase request);

        Task<int> Delete(int productID);
    }
}
