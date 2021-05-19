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
        //private const string URL = "http://10.0.2.2:43343/api/zones";
        public IRestService RestService => DependencyService.Get<IRestService>();
        public MapsService()
        {
        }

        public Task<Zone> GetZoneAsync(string id)
        {
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var client = new HttpClient())
                {
                    string URL1 = "http://10.0.2.2:43343/api/cars/" + id;
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL1);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Zone>(jsonResponse);
                    return response;
                }
            });

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

        /*
         * 
         * 
            JObject ojObject = (JObject)response["results"];
                            JArray array = (JArray)ojObject["places"];
        public async Task<bool> AddCarAsync(Zone zone)
        {

            using (var client = new HttpClient())
            {
                string URL2 = "http://10.0.2.2:43343/api/cars";
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);

                var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(URL2, content);
                responseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<Car>(jsonResponse);
                return await Task.FromResult(true);

            };
        }


        public async Task<bool> UpdateCarAsync(string id, Zone zone)
        {

            using (var client = new HttpClient())
            {
                string URL3 = "http://10.0.2.2:43343/api/cars/" + id;
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);

                var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync(URL3, content);
                responseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<Car>(jsonResponse);
                return await Task.FromResult(true);

            };
        }
        */
    }
}
