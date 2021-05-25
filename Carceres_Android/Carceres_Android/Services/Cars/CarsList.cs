using Carceres_Android.Models;
using Carceres_Android.Services.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.Services.Cars
{
    public class CarsList : ICarsList<Car>
    {
        
        private const string URL = "http://10.0.2.2:43343/api/client/cars";
        public IRestService RestService => DependencyService.Get<IRestService>();
        public CarsList()
        {
        }

        public Task<Car> GetCarAsync(string id)
        {
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var client = new HttpClient())
                {
                    string URL1 = "http://10.0.2.2:43343/api/client/cars/" + id;
                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL1);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Car>(jsonResponse);
                    return response;
                }
            });

        }
        public Task<List<Car>> GetCarsAsync()
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
                    List<Car> Cars = response.results.ToObject<List<Car>>();
                    return Cars;
                }
            });

        }
    }
}
