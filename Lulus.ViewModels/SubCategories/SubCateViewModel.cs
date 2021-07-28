using Lulus.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.SubCategories
{
    public class SubCateViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public CategoryViewModel Category { get; set; }
        public bool Checked { get; set; } = false;
    }
}
