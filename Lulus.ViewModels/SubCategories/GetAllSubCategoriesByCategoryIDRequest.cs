using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.SubCategories
{
    public class GetAllSubCategoriesByCategoryIDRequest
    {
        public int CategoryID { get; set; }
        public GetAllSubCategoriesByCategoryIDRequest() { }
        public GetAllSubCategoriesByCategoryIDRequest(int id)
        {
            this.CategoryID = id;
        }
    }
}
