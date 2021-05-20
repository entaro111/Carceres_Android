using Carceres_Android.Models;
using Carceres_Android.Services.API;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.Services.Clients
{
    public class ClientsList : IClientsList
    {
        private const string URL = "http://10.0.2.2:43343/api/clients";
        public IRestService RestService => DependencyService.Get<IRestService>();
        //public List<Car> Cars { get; private set; }
        public ClientsList()
        {
        }

        public Task<IList<Models.Clients>> GetClientsAsync()
        {
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);

                    var responseMessage = await httpClient.GetAsync(URL);

                    responseMessage.EnsureSuccessStatusCode();

                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                    JObject response = JObject.Parse(jsonResponse);

                    IList<JToken> results = response["results"].Children().ToList();
                    IList<Models.Clients> ClientsList = new List<Models.Clients>();
                    foreach (JToken result in results)
                    {
                        Models.Clients client = result.ToObject<Models.Clients>();
                        ClientsList.Add(client);
                    }
                    //var response = JsonConvert.DeserializeObject<IEnumerable<Car>>(jsonResponse);
                    return ClientsList;
                }
            });

        }

    }
}
