using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Cars
{
    public interface ICarsList<T>
    {
        Task<bool> AddCarAsync(T car);
        Task<bool> UpdateCarAsync(T car);
        Task<bool> DeleteCarAsync(string id);
        Task<T> GetCarAsync(string id);
        Task<IEnumerable<T>> GetCarsAsync(bool forceRefresh = false);
    }
}
