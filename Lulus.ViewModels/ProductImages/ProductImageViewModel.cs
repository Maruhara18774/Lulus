using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.ProductImages
{
    public class ProductImageViewModel
    {
        public int ID { get; set; }

        public string Image_Url { get; set; }
        public IFormFile Image_Image { get; set; }

        public int ProductLine_ID { get; set; }

    }
}
