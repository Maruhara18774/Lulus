using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.ProductLines
{
    class CreateProductLineRequest
    {
        public int ProductLine_ID { get; set; }

        public string Texture_Name { get; set; }

        public IFormFile Texture_Image { get; set; }

        public DateTime ProductLine_CreatedDate { get; set; }

        public DateTime ProductLine_UpdatedDate { get; set; }

        public int Product_ID { get; set; }
    }
}
