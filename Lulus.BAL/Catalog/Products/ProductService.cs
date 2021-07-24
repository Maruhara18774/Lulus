
using Lulus.BAL.Catalog.Products.DTOs;
using Lulus.BAL.Catalog.Products.DTOs.Public;
using Lulus.BAL.Catalog.Products.Interfaces;
using Lulus.Data.EF;
using Lulus.ViewModels.Feedbacks;
using Lulus.ViewModels.ProductImages;
using Lulus.ViewModels.ProductLines;
using Lulus.ViewModels.Products;
using Lulus.ViewModels.Sizes;
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

        public async Task<List<ProductViewModel>> GetAllBySubCateID(DTOs.Public.GetProductPagingRequest request)
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

        public async Task<ProductViewModel> GetDetailByID(GetProductDetailRequest request)
        {
            var query = from p in _context.Products
                        where p.Product_ID == request.ID
                        select p;
            if (query == null) return null;
            ProductViewModel result = await query.Select(p => new ProductViewModel()
            {
                ID = p.Product_ID,
                Name = p.Product_Name,
                Price = p.Product_Price,
                SalePrice = p.Product_SalePrice,
                Description = p.Product_Description,
                Status = p.Status
            }).SingleOrDefaultAsync();
            var productLines = from pl in _context.ProductLines
                               where pl.Product_ID == result.ID
                               select pl;
            result.ListProductLines = await productLines.Select(p => new ProductLineViewModel()
            {
                ID = p.ProductLine_ID,
                Texture_Name = p.Texture_Name,
                Texture_Image_Url = p.Texture_Image,
                CreatedDate = p.ProductLine_CreatedDate,
                UpdatedDate = p.ProductLine_UpdatedDate,
                Product_ID = p.Product_ID
            }).ToListAsync();
            foreach (var line in result.ListProductLines)
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
                    Key = s.Size_Key,
                }).ToListAsync();
                foreach(var size in line.ListSizes)
                {
                    var quantity = from q in _context.LineQuantities
                                   where q.ProductLine_ID == line.ID && q.Size_ID == size.ID
                                   select q;
                    size.Quantity = quantity.Select(s => s.Quantity).FirstOrDefault();
                }
            }
            var feedbacks = from f in _context.Feedbacks
                            where f.Product_ID == result.ID
                            select f;
            result.ListFeedbacks = await feedbacks.Select(f => new FeedbackViewModel()
            {
                ID = f.Feedback_ID,
                Star = f.Feedback_Rating,
                Title = f.Feedback_Title,
                Content = f.Feedback_Content,
                UserID = f.User_ID,
                CreatedDate = f.CreatedDate,
                ProductID = f.Product_ID
            }).ToListAsync();
            return result;
        }
    }
}
