using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class Size
    {
        [Key]
        public int Size_ID { get; set; }

        [MaxLength(10)]
        public string Size_Key { get; set; }
    }
}
