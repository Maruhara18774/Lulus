using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.Products
{
    public class GetProductDetailRequest
    {
        public int ID { get; set; }
        public GetProductDetailRequest() { }
        public GetProductDetailRequest(int productId) { this.ID = productId; }
    }
}
