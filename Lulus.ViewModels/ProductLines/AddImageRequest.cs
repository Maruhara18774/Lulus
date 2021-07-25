using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.ProductLines
{
    public class AddImageRequest
    {
        public int ProductLineID { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
