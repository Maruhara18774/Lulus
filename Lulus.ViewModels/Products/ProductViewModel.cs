
using Lulus.Data.Enums;
using Lulus.ViewModels.Feedbacks;
using Lulus.ViewModels.ProductLines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.Products
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
        public double SalePrice { get; set; }

        public string Description { get; set; }

        public int SubCategory_ID { get; set; }

        public ProductStatus Status { get; set; }
        public List<ProductLineViewModel> ListProductLines { get; set; } = new List<ProductLineViewModel>();

        public List<FeedbackViewModel> ListFeedbacks { get; set; } = new List<FeedbackViewModel>();
    }
}
