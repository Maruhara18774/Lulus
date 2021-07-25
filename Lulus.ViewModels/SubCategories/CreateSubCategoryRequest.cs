using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.SubCategories
{
    public class CreateSubCategoryRequest
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
