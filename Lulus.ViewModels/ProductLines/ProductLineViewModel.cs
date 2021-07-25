using Lulus.ViewModels.LineQuantity;
using Lulus.ViewModels.ProductImages;
using Lulus.ViewModels.Sizes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.ProductLines
{
    public class ProductLineViewModel
    {
        public int ID { get; set; }

        public string Texture_Name { get; set; }

        public string Texture_Image_Url { get; set; }
        public IFormFile Texture_Image_Image { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int Product_ID { get; set; }
        public List<ProductImageViewModel> ListImages { get; set; }
        public List<SizeViewModel> ListSizes { get; set; }
        public List<LineQuantityViewModel> ListQuantity { get; set; }
    }
}
