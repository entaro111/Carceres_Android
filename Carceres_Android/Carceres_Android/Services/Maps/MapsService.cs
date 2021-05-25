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

namespace Carceres_Android.Services.Maps
{
    public class MapsService : IMapsService<Zone>
    {
        private string URL => Preferences.Get("apiurl", string.Empty);
        public IRestService RestService => DependencyService.Get<IRestService>();
        public MapsService()
        {
        }

        public async Task<List<Zone>> GetZonesAsync()
        {
                using (var client = new HttpClient())
                {
                    
                    string endpoint = "zones";
                    client.DefaultRequestHeaders.Add("Connection", "close");
                    client.DefaultRequestHeaders.Add("Accept-Encoding", "identity");
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL+endpoint);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    dynamic response = JsonConvert.DeserializeObject(jsonResponse);
                    List<Zone> Zones = response.results.ToObject<List<Zone>>();

                    return Zones;
                }
        }

        public async Task<ZoneInfo> GetZoneInfoAsync(string id)
        {
            using(var client = new HttpClient())
            {
               
                string endpoint = $"zones/{id}/info";
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                var responseMessage = await client.GetAsync(URL+endpoint);
                responseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                dynamic respone = JsonConvert.DeserializeObject(jsonResponse);
                ZoneInfo info = respone.ToObject<ZoneInfo>();
                return info;
            }
        }

        public Task<Zone> GetZoneAsync(string id)
        {
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var client = new HttpClient())
                {
                    string endpoint = "zones/" + id;
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL + endpoint);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Zone>(jsonResponse);
                    return response;
                }
            });
        }
    }
}
