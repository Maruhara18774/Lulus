using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class ProductLine
    {
        [Key]
        public int ProductLine_ID { get; set; }

        public string Texture_Name { get; set; }

        public string Texture_Image { get; set; }

        public DateTime ProductLine_CreatedDate { get; set; }

        public DateTime ProductLine_UpdatedDate { get; set; }

        public int Product_ID { get; set; }
    }
}
