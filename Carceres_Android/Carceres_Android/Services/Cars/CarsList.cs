using Carceres_Android.Models;
using Carceres_Android.Services.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Carceres_Android.Services.Cars
{
    public class CarsList : ICarsList
    {

        private const string URL = "http://10.0.2.2:43343/api/cars";
        public IRestService RestService => DependencyService.Get<IRestService>();
        public CarsList()
        {
        }

        public Task<IEnumerable<Car>> GetCarsAsync()
        {
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var client = new HttpClient())
                {

                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);

                    var responseMessage = await client.GetAsync(URL);

                    responseMessage.EnsureSuccessStatusCode();

                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                    var response = JsonConvert.DeserializeObject<IEnumerable<Car>>(jsonResponse);
                    System.Console.ReadKey();
                    return response;
                }
            });

        }
      
    }
}
