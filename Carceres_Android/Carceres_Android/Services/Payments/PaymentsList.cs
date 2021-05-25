using Carceres_Android.Models;
using Carceres_Android.Services.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Carceres_Android.Services.Payments
{
    public class PaymentsList : IPaymentsList<Payment>
    {
        private string URL => Preferences.Get("apiurl", string.Empty);
        public IRestService RestService => DependencyService.Get<IRestService>();
        public PaymentsList()
        {
        }

        public Task<List<Payment>> GetPaymentsAsync()
        {
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var client = new HttpClient())
                {
                    string endpoint = "client/payments";
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL + endpoint);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    dynamic response = JsonConvert.DeserializeObject(jsonResponse);
                    List<Payment> Payments = response.results.ToObject<List<Payment>>();   
                    return Payments;
                }
            });

        }


        public Task<Payment> GetPaymentAsync(string id)
        {
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var client = new HttpClient())
                {
                    string endpoint = "client/payments/" + id;
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL + endpoint);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Payment>(jsonResponse);
                    return response;
                }
            });
        }

        public async Task<bool> UpdatePaymentAsync(string id)
        {
            using (var client = new HttpClient())
            {
                string endpoint = "client/payments" + id;
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                var responseMessage = await client.PutAsync(URL + endpoint,null);
                responseMessage.EnsureSuccessStatusCode();
                return await Task.FromResult(true);
            }
        }
    }
}
