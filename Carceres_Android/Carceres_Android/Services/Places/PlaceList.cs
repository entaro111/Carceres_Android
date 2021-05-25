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
                string URL = "http://10.0.2.2:43343/api/places?limit=110";
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                var responseMessage = await client.GetAsync(URL);
                responseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                dynamic response = JsonConvert.DeserializeObject(jsonResponse);
                List<Models.Places> Places = response.results.ToObject<List<Models.Places>>();
                return Places;
            }
        }
    }
}
