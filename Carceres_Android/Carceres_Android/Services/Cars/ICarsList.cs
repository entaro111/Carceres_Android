using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Cars
{
    public interface ICarsList
    {
        Task<IList<Car>> GetCarsAsync();
        /*
        Task<bool> AddCarAsync(T car);
        Task<bool> UpdateCarAsync(T car);
        Task<bool> DeleteCarAsync(string id);
        Task<T> GetCarAsync(string id);
        
        Task<IEnumerable<T>> GetCarsAsync(bool forceRefresh = false);
        */
    }
}
