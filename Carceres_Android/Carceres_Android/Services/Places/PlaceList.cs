using Carceres_Android.Services.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.Services.Places
{
    public class PlaceList : IPlaceList<Models.Places>
    {
        public IRestService RestService => DependencyService.Get<IRestService>();

        public PlaceList() { }

        public async Task<List<Models.Places>> GetPlacesAsync()
        {
            using (var client = new HttpClient())
            {
                string count = "";
                string URL = "http://10.0.2.2:43343/api/places";
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                var responseMessage = await client.GetAsync(URL);
                responseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                dynamic response = JsonConvert.DeserializeObject(jsonResponse);
                count = response.count;

                string URL1 = "http://10.0.2.2:43343/api/places?limit="+count;
                var responseMessage1 = await client.GetAsync(URL1);
                responseMessage1.EnsureSuccessStatusCode();
                var jsonResponse1 = await responseMessage1.Content.ReadAsStringAsync();
                dynamic response1 = JsonConvert.DeserializeObject(jsonResponse1);
                List<Models.Places> Places = response1.results.ToObject<List<Models.Places>>();

                return Places;
            }
        }
    }
}
