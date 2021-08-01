using Lulus.CustomerApp.Services.Interfaces;
using Lulus.ViewModels.Feedbacks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Services
{
    public class FeedbackApi : IFeedbackApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string MyUrl = "https://lulusbackendapi.azurewebsites.net";
        public FeedbackApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CreateFeedback(CreateFeedbackRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(MyUrl);
            var respond = await client.PostAsync("/api/Feedback/CreateFeedback", httpcontent);
            var body = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                return true;
            }
;
            return false;
        }
    }
}
