using Lulus.BAL.Catalog.ProductLines.Interfaces;
using Lulus.Data.EF;
using Lulus.ViewModels.LineQuantity;
using Lulus.ViewModels.ProductImages;
using Lulus.ViewModels.ProductLines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lulus.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lulus.BAL.Catalog.ProductLines
{
    public class ManageProductLineService : IManageProductLineService
    {
        private readonly LulusDBContext _context;
        public ManageProductLineService(LulusDBContext context)
        {
            _context = context;
        }
        public async Task<int> AddImage(AddImageRequest request)
        {
            var image = new ProductImage()
            {
                ProductLine_ID = request.ProductLineID,
                ProductImage_Image =request.ImageUrl
            };
            _context.ProductImages.Add(image);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddQuantity(AddQuantityRequest request)
        {
            var line = await _context.LineQuantities.FindAsync(request.ID);
            if(line == null)
            {
                var lineQuantity = new LineQuantity()
                {
                    ProductLine_ID = request.ProductLineID,
                    Size_ID = request.Size_ID,
                    Quantity = request.Quantity
                };
                _context.LineQuantities.Add(lineQuantity);
            }
            else
            {
                line.ProductLine_ID = request.ProductLineID;
                line.Size_ID = request.Size_ID;
                line.Quantity = request.Quantity;
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreateProductLine(CreateProductLineRequest request)
        {
            var line = new ProductLine()
            {
                Texture_Name = request.Texture_Name,
                Texture_Image = request.Texture_ImageUrl,
                Product_ID = request.Product_ID,
                ProductLine_CreatedDate = DateTime.Now,
                ProductLine_UpdatedDate = DateTime.Now
            };
            _context.ProductLines.Add(line);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteImage(DeleteImageRequest request)
        {
            var image = await _context.ProductImages.FindAsync(request.ImageID);
            if (image == null) return false;
            _context.ProductImages.Remove(image);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductImageViewModel>> GetAllImage(GetAllImageByIDRequest request)
        {
            var query = from i in _context.ProductImages
                        where i.ProductLine_ID == request.ProductLineID
                        select i;
            var data = await query.Select(i => new ProductImageViewModel()
            {
                ID = i.ProductImage_ID,
                ProductLine_ID = i.ProductLine_ID,
                Image_Url = i.ProductImage_Image,
            }).ToListAsync();
            return data;
        }

        public async Task<List<ProductLineViewModel>> GetAllLinesByID(GetAllLinesByIDRequest request)
        {
            var query = from l in _context.ProductLines
                        where l.Product_ID == request.ProductID
                        select l;
            var data = await query.Select(l => new ProductLineViewModel()
            {
                ID = l.ProductLine_ID,
                Texture_Name = l.Texture_Name,
                Texture_Image_Url = l.Texture_Image,
                CreatedDate = l.ProductLine_CreatedDate,
                UpdatedDate = l.ProductLine_UpdatedDate,
                Product_ID = l.Product_ID
            }).ToListAsync();
            foreach (var line in data)
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
                var quantity = from q in _context.LineQuantities
                               where q.ProductLine_ID == line.ID
                               select q;
                line.ListQuantity = await quantity.Select(s => new LineQuantityViewModel()
                {
                    ID = s.LineQuantity_ID,
                    ProductLineID = s.ProductLine_ID,
                    SizeID = s.Size_ID,
                    Quantity = s.Quantity
                }).ToListAsync();
                foreach(var quan in line.ListQuantity)
                {
                    var key = from s in _context.Sizes
                              where quan.SizeID == s.Size_ID
                              select s;
                    quan.SizeKey = key.Select(s => s.Size_Key).FirstOrDefault();
                }
            }
            return data;
        }

        public async Task<bool> UpdateProductLine(CreateProductLineRequest request)
        {
            var line = await _context.ProductLines.FindAsync(request.ProductLine_ID);
            if (line == null) return false;
            line.Texture_Name = request.Texture_Name;
            line.Texture_Image = request.Texture_ImageUrl;
            line.ProductLine_UpdatedDate = DateTime.Now;
            line.Product_ID = request.Product_ID;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateQuantity(UpdateQuantityRequest request)
        {
            var line = await _context.LineQuantities.FindAsync(request.LineQuantityID);
            if (line == null) return false;
            line.Quantity = request.Quantity;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
