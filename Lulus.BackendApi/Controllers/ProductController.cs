using Lulus.BAL.Catalog.Products.DTOs.Public;
using Lulus.BAL.Catalog.Products.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.BackendApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> GetByCateID(GetProductPagingRequest request)
        {
            var result = await _productService.GetAllByCateID(request);
            foreach (var product in result)
            {
                foreach (var line in product.ListProductLines)
                {
                    line.Texture_Image_Url = "https://localhost:44354"+line.Texture_Image_Url;
                    foreach(var image in line.ListImages)
                    {
                        image.Image_Url = "https://localhost:44354" + image.Image_Url;
                    }
                    //var imageFileStream = System.IO.File.OpenRead(line.Texture_Image_Url);
                    //line.Texture_Image_Image =  new FormFile(imageFileStream,0,imageFileStream.Length,null,line.Texture_Image_Url)
                    //{
                    //    Headers = new HeaderDictionary(),
                    //    ContentType = "image/jpeg"
                    //};
                }
            }
            return Ok(result);
        }
    }
}
