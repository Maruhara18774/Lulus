using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class SubCategory
    {
        public int SubCategory_ID { get; set; }
        public string SubCategory_Name { get; set; }

        public int Category_ID { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual Category Category { get; set; }
    }
}
