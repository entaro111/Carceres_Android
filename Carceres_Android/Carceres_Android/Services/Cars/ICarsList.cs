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
        Task<IList<T>> GetCarsAsync();
        Task<bool> AddCarAsync(T car);
    }
}
