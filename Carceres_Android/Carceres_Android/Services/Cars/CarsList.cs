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
        
        private const string URL = "http://10.0.2.2:43343/api/cars";
        public IRestService RestService => DependencyService.Get<IRestService>();
        //public List<Car> Cars { get; private set; }
        public CarsList()
        {
        }

        public Task<Car> GetCarAsync(string id)
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
                    var response = JsonConvert.DeserializeObject<Car>(jsonResponse);
                    return response;
                }
            });

        }
        public Task<IList<Car>> GetCarsAsync()
        {
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    JObject response = JObject.Parse(jsonResponse);
                    IList<JToken> results = response["results"].Children().ToList();
                    IList<Car> Cars = new List<Car>();
                    foreach (JToken result in results)
                    {
                        Car car = result.ToObject<Car>();
                        Cars.Add(car);
                    }
                    return Cars;
                }
            });

        }

        public async Task<bool> AddCarAsync(Car car)
        {
           // return RestService.ExecuteWithRetryAsync(async () =>
          //  {
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
                    //return response;
                };
        }
    }
}
