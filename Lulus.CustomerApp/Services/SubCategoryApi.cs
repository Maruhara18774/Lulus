using Lulus.CustomerApp.Services.Interfaces;
using Lulus.ViewModels.SubCategories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Services
{
    public class SubCategoryApi : ISubCategoryApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string MyUri = "https://lulusbackendapi.azurewebsites.net";
        public SubCategoryApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<SubCateViewModel>> GetList(GetAllSubCategoriesByCategoryIDRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(MyUri);
            var respond = await client.PostAsync("/api/SubCategory/GetList", httpcontent);
            var body = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<SubCateViewModel>>(body);
            }

            return new List<SubCateViewModel>();
        }
    }
}
