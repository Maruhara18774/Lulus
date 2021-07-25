using Lulus.ViewModels.LineQuantity;
using Lulus.ViewModels.ProductImages;
using Lulus.ViewModels.ProductLines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.ProductLines.Interfaces
{
    public interface IManageProductLineService
    {
        public Task<List<ProductLineViewModel>> GetAllLinesByID(GetAllLinesByIDRequest request);
        public Task<int> CreateProductLine(CreateProductLineRequest request);
        public Task<bool> UpdateProductLine(CreateProductLineRequest request);

        public Task<List<ProductImageViewModel>> GetAllImage(GetAllImageByIDRequest request);
        public Task<int> AddImage(AddImageRequest request);
        public Task<bool> DeleteImage(DeleteImageRequest request);
        public Task<int> AddQuantity(AddQuantityRequest request);
        public Task<bool> UpdateQuantity(UpdateQuantityRequest request);
    }
}
