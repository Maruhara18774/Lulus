using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class Category
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
