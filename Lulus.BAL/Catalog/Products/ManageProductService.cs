
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
                Status = ProductStatus.StopBusiness
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
