using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Cars
{
    public class CarsList : ICarsList<Car>
    {
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
    }
}
