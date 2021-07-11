
using Lulus.BAL.Catalog.Products.DTOs;
using Lulus.BAL.Catalog.Products.DTOs.Manage;
using Lulus.BAL.Catalog.Products.Interfaces;
using Lulus.BAL.DTOs;
using Lulus.Data.EF;
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
        public async Task<PagedResult<ProductViewModel>> GetAllBySubCateID(DTOs.Public.GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        where p.SubCategory_ID == request.SubCateId
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

            var pagedResult = new DTOs.PagedResult<ProductViewModel>()
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
