using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class Category
    {
        [Key]
        public int Category_ID { get; set; }
        [MaxLength(100)]
        public string Category_Name { get; set; }
    }
}
