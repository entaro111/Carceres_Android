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

        private const string URL = "http://10.0.2.2:43343/api/cars/1";
        public IRestService RestService => DependencyService.Get<IRestService>();
        public CarsList()
        {
        }

        public Task<IEnumerable<Car>> GetCarsAsync()
        {
            /*
            using (var client = new HttpClient())
            {
                string token = Preferences.Get("BearerToken", string.Empty);
                
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-access-tokens", token);
                var responseMessage = await client.GetAsync(URL);

                responseMessage.EnsureSuccessStatusCode();

                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<IEnumerable<Car>>(jsonResponse);

                return response;
            };
}
        */
            return RestService.ExecuteWithRetryAsync(async () =>
            {
                using (var client = new HttpClient())
                {
                //client.DefaultRequestHeaders.Add("Authorization", $"x-access-tokens {RestService.accessToken}");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-access-tokens", RestService.accessToken);
                //client.DefaultRequestHeaders.Add("x-access-token", RestService.accessToken);
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);

                    var responseMessage = await client.GetAsync(URL);

                    responseMessage.EnsureSuccessStatusCode();

                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                    var response = JsonConvert.DeserializeObject<IEnumerable<Car>>(jsonResponse);

                    return response;
                }
            });

        }
        /*
        readonly List<Car> cars;

        public CarsList()
        {
            cars = new List<Car>()
            {
                new Car { id = Guid.NewGuid().ToString(), plate = "Test1", brand = "Administrator" },
                new Car { id = Guid.NewGuid().ToString(), plate = "Test2", brand = "Klient" },
                new Car { id = Guid.NewGuid().ToString(), plate = "Test3", brand = "Bot" }
            };
        }

        public async Task<bool> AddCarAsync(Car car)
        {
            cars.Add(car);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateCarAsync(Car car)
        {
            var oldCar = cars.Where((Car arg) => arg.id == car.id).FirstOrDefault();
            cars.Remove(oldCar);
            cars.Add(car);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCarAsync(string id)
        {
            var oldCar = cars.Where((Car arg) => arg.id == id).FirstOrDefault();
            cars.Remove(oldCar);

            return await Task.FromResult(true);
        }

        public async Task<Car> GetCarAsync(string id)
        {
            return await Task.FromResult(cars.FirstOrDefault(s => s.id == id));
        }

        public async Task<IEnumerable<Car>> GetCarsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(cars);
        }
        */
    }
}
