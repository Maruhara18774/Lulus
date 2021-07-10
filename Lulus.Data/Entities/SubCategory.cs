using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class SubCategory
    {
        [Key]
        public int SubCategory_ID { get; set; }
        [MaxLength(100)]
        public string SubCategory_Name { get; set; }
    }
}
