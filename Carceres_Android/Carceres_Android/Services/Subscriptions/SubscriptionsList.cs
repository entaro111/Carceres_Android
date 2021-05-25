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
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Carceres_Android.Services.Reservations
{
    public class SubscriptionsList : ISubscriptionsList<Subscription>
    {
        private string URL => Preferences.Get("apiurl", string.Empty);

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
                    string endpoint = "client/subscriptions";
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL+endpoint);
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
                    string endpoint = "client/subscriptions/" + id;
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL+endpoint);
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
                string endpoint = "client/subscriptions";
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                var content = new StringContent(JsonConvert.SerializeObject(subscription), Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(URL+endpoint,content);
                responseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<Subscription>(jsonResponse);
                return await Task.FromResult(true);
            };
        }
    }
}
