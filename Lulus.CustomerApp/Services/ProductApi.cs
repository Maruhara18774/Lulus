using Lulus.BAL.Catalog.Products.DTOs.Public;
using Lulus.CustomerApp.Services.Interfaces;
using Lulus.ViewModels.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Services
{
    public class ProductApi : IProductApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<ProductViewModel>> GetListByCateID(GetProductPagingRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44354");
            var respond = await client.PostAsync("/api/Product/GetByCateID", httpcontent);
            var body = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<ProductViewModel>>(body);
            }

            return new List<ProductViewModel>();
        }
        public async Task<List<ProductViewModel>> GetListBySubCateID(GetProductPagingRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44354");
            var respond = await client.PostAsync("/api/Product/GetBySubCateID", httpcontent);
            var body = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<ProductViewModel>>(body);
            }

            return new List<ProductViewModel>();
        }
        public async Task<ProductViewModel> GetDetailByID(GetProductDetailRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44354");
            var respond = await client.PostAsync("/api/Product/GetDetailByID", httpcontent);
            var body = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductViewModel>(body);
            }

            return new ProductViewModel();
        }
    }
}
