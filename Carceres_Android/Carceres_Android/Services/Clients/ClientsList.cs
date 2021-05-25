using Carceres_Android.Services.API;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Carceres_Android.Services.Clients
{
    public class ClientsList : IClientsList<Models.Clients>
    {
        //private const string URL = "http://10.0.2.2:43343/api/;
        private string URL => Preferences.Get("apiurl", string.Empty);
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
                    string endpoint = "client";
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL+ endpoint);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Models.Clients>(jsonResponse);
                    return response;
                }
            });

        }

        public async Task<bool> UpdateClientAsync(Models.Clients updatedClient)
        {
            using (var client = new HttpClient())
            {
                string endpoint = "client";
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                var content = new StringContent(JsonConvert.SerializeObject(updatedClient), Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync(URL+ endpoint, content);
                responseMessage.EnsureSuccessStatusCode();
                return await Task.FromResult(true);

            };
        }

    }
}
