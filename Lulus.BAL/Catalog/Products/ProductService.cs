﻿
using Lulus.BAL.Catalog.Products.DTOs;
using Lulus.BAL.Catalog.Products.DTOs.Public;
using Lulus.BAL.Catalog.Products.Interfaces;
using Lulus.Data.EF;
using Lulus.ViewModels.ProductImages;
using Lulus.ViewModels.ProductLines;
using Lulus.ViewModels.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly LulusDBContext _context;

        public ProductService(LulusDBContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAllByCateID(GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join sc in _context.SubCategories on p.SubCategory_ID equals sc.SubCategory_ID
                        where sc.Category_ID == request.ID 
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
            foreach(var item in data)
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
                foreach(var line in item.ListProductLines)
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
                }
            }
            return data;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllBySubCateID(DTOs.Public.GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        where p.SubCategory_ID == request.ID
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

            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data,
            };
            return pagedResult;
        }
    }
}
