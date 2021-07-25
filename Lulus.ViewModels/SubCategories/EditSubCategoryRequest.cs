using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.SubCategories
{
    public class EditSubCategoryRequest
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
