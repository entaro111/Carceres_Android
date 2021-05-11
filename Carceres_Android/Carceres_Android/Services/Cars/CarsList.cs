using Carceres_Android.Models;
using Carceres_Android.Services.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.Services.Cars
{
    public class CarsList : ICarsList
    {

        private const string URL = "http://10.0.2.2:43343/api/cars";
        public IRestService RestService => DependencyService.Get<IRestService>();
        //public List<Car> Cars { get; private set; }
        public CarsList()
        {
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

                    JObject response= JObject.Parse(jsonResponse);

                    IList<JToken> results = response["results"].Children().ToList();
                    IList<Car> Cars = new List<Car>();
                    foreach (JToken result in results)
                    {
                        Car car = result.ToObject<Car>();
                        Cars.Add(car);
                    }
                    //var response = JsonConvert.DeserializeObject<IEnumerable<Car>>(jsonResponse);
                    return Cars;
                }
            });

        }
      
    }
}
