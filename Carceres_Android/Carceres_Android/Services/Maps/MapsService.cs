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

namespace Carceres_Android.Services.Maps
{
    public class MapsService : IMapsService<Zone>
    {
        public IRestService RestService => DependencyService.Get<IRestService>();
        public MapsService()
        {
        }

        public async Task<List<Zone>> GetZonesAsync()
        {           
            
                using (var client = new HttpClient())
                {
                    string URL = "http://10.0.2.2:43343/api/zones";
                    client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                    client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL);
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
                string URL = $"http://10.0.2.2:43343/api/zones/{id}/info";
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                var responseMessage = await client.GetAsync(URL);
                responseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                dynamic respone = JsonConvert.DeserializeObject(jsonResponse);
                ZoneInfo info = respone.ToObject<ZoneInfo>();
                return info;
            }
        }
    }
}
