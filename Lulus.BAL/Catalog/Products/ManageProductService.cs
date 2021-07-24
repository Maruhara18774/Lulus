
using Lulus.BAL.Catalog.Products.Interfaces;
using Lulus.Data.EF;
using Lulus.Data.Entities;
using Lulus.Data.Enums;
using Lulus.ViewModels.Products;
using Lulus.ViewModels.Products.Manage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly LulusDBContext _context;
        public ManageProductService(LulusDBContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Product_Name = request.Name,
                Product_Price = request.Price,
                Product_SalePrice = request.SalePrice,
                Product_Description = request.Description,
                SubCategory_ID = request.SubCategoryID,
                Status = ProductStatus.Stocking
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productID)
        {
            var product = await _context.Products.FindAsync(productID);
            product.Status = ProductStatus.StopBusiness;
            return await _context.SaveChangesAsync();
        }

        public Task<List<ProductViewModel>>  GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ViewModels.Products.PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join sc in _context.SubCategories on p.SubCategory_ID equals sc.SubCategory_ID
                        join c in _context.Categories on sc.Category_ID equals c.Category_ID
                        where p.Product_Name.Contains(request.Keyword) || sc.SubCategory_Name.Contains(request.Keyword) || c.Category_Name.Contains(request.Keyword)
                        select p;
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1)*request.PageSize).Take(request.PageSize)
                .Select(p => new ProductViewModel()
                {
                    ID = p.Product_ID,
                    Name = p.Product_Name,
                    Price = p.Product_Price,
                    SalePrice = p.Product_SalePrice,
                    Description = p.Product_Description,
                    SubCategory_ID = p.SubCategory_ID,
                    Status = p.Status
                }).ToListAsync();

            var pagedResult = new ViewModels.Products.PagedResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data,
            };
            return pagedResult;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            product.Product_Name = request.Name;
            product.Product_Price = request.Price;
            product.Product_SalePrice = request.SalePrice;
            product.Product_Description = request.Description;
            product.SubCategory_ID = request.SubCategoryID;
            product.Status = request.Status;
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(UpdatePriceRequest request)
        {
            var product = await _context.Products.FindAsync(request.ProductID);

            if (product == null) return false;
            product.Product_Price = request.OriginalPrice;
            product.Product_SalePrice = request.SalePrice;
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
