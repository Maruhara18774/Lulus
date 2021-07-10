using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class ProductImage
    {
        [Key]
        public int ProductImage_ID { get; set; }

        public string ProductImage_Image { get; set; }

        public int ProductLine_ID { get; set; }

    }
}
