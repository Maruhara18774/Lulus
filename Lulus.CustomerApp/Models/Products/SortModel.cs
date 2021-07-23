using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Models.Products
{
    public class SortModel
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public int CategoryID { get; set; }
        public int SubcategoryID { get; set; }
        public SortModel() { }
        public SortModel(int cateID, int subcateID) {
            this.CategoryID = cateID;
            this.SubcategoryID = subcateID;
        }
    }
}
