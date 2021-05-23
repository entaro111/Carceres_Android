using Carceres_Android.Services.API;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.Services.Clients
{
    public class ClientsList : IClientsList<Models.Clients>
    {
        private const string URL = "http://10.0.2.2:43343/api/client";
        public IRestService RestService => DependencyService.Get<IRestService>();

        public ClientsList()
        {
        }

        public Task<Models.Clients> GetClientAsync()
        {
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var client = new HttpClient())
                {
                    
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Models.Clients>(jsonResponse);
                    return response;
                }
            });

        }

    }
}
