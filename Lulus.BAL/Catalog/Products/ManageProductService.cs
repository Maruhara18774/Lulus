
using Lulus.BAL.Catalog.Products.Interfaces;
using Lulus.Data.EF;
using Lulus.Data.Entities;
using Lulus.Data.Enums;
using Lulus.ViewModels.Common;
using Lulus.ViewModels.ProductImages;
using Lulus.ViewModels.ProductLines;
using Lulus.ViewModels.Products;
using Lulus.ViewModels.Products.Manage;
using Lulus.ViewModels.Sizes;
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
            if (product == null) return 0;
            product.Status = ProductStatus.StopBusiness;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetAllProduct(PagingRequestBase request)
        {
            var query = from p in _context.Products
                        select p;

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
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
            foreach (var item in data)
            {
                var productLines = from pl in _context.ProductLines
                                   where pl.Product_ID == item.ID
                                   select pl;
                item.ListProductLines = await productLines.Select(p => new ProductLineViewModel()
                {
                    ID = p.ProductLine_ID,
                    Texture_Name = p.Texture_Name,
                    Texture_Image_Url = p.Texture_Image,
                    CreatedDate = p.ProductLine_CreatedDate,
                    UpdatedDate = p.ProductLine_UpdatedDate,
                    Product_ID = p.Product_ID
                }).ToListAsync();
                foreach (var line in item.ListProductLines)
                {
                    var productImages = from i in _context.ProductImages
                                        where i.ProductLine_ID == line.ID
                                        select i;
                    line.ListImages = await productImages.Select(i => new ProductImageViewModel()
                    {
                        ID = i.ProductImage_ID,
                        Image_Url = i.ProductImage_Image,
                        ProductLine_ID = i.ProductLine_ID
                    }).ToListAsync();
                    var productSizes = from s in _context.Sizes
                                       join q in _context.LineQuantities on s.Size_ID equals q.Size_ID
                                       where q.ProductLine_ID == line.ID
                                       select s;
                    line.ListSizes = await productSizes.Select(s => new SizeViewModel()
                    {
                        ID = s.Size_ID,
                        Key = s.Size_Key
                    }).ToListAsync();
                }
            }
            return data;
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
