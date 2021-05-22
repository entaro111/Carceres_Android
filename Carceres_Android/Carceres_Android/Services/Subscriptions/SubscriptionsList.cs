using Carceres_Android.Models;
using Carceres_Android.Services.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.Services.Reservations
{
    public class SubscriptionsList : ISubscriptionsList<Subscription>
    {
        private const string URL = "http://10.0.2.2:43343/api/client/subscriptions";
        public IRestService RestService => DependencyService.Get<IRestService>();
        public SubscriptionsList()
        {
        }

        public Task<List<Subscription>> GetSubscriptionsAsync()
        {
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    dynamic response = JsonConvert.DeserializeObject(jsonResponse);
                    List<Subscription> Subscriptions = response.results.ToObject<List<Subscription>>();
                    return Subscriptions;
                }
            });

        }

        public Task<Subscription> GetSubscriptionAsync(string id)
        {
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var client = new HttpClient())
                {
                    string URL1 = "http://10.0.2.2:43343/api/subscriptions/" + id;
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL1);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Subscription>(jsonResponse);
                    return response;
                }
            });
        }

        
        public async Task<bool> AddSubscriptionAsync(Subscription subscription)
        {
            using (var client = new HttpClient())
            {
                string URL = "http://10.0.2.2:43343/api/client/subscriptions";
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                var content = new StringContent(JsonConvert.SerializeObject(subscription), Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(URL,content);
                responseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<Subscription>(jsonResponse);
                return await Task.FromResult(true);
            };
        }
    }
}
