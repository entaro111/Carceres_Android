using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Cars
{
    public interface ICarsList<T>
    {
        Task<T> GetCarAsync(string id);
        Task<List<T>> GetCarsAsync();
       // Task<bool> UpdateCarAsync(string id, T car);
       // Task<bool> AddCarAsync(T car);
    }
}
