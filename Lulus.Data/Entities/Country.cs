using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class Country
    {
        [Key]
        public int Country_ID { get; set; }

        [MaxLength(100)]
        public string Country_Name { get; set; }
    }
}
