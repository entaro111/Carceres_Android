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
using Xamarin.Forms;

namespace Carceres_Android.Services.Payments
{
    public class PaymentsList : IPaymentsList<Payment>
    {
        private const string URL = "http://10.0.2.2:43343/api/client/payments";
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

                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL);
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
                    string URL1 = "http://10.0.2.2:43343/api/payments/" + id;
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL1);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Payment>(jsonResponse);
                    return response;
                }
            });
        }
    }
}
