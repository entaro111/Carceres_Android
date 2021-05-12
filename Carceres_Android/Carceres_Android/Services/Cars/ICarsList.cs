using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Cars
{
    public interface ICarsList
    {
        Task<Car> GetCarAsync(string id);
        Task<IList<Car>> GetCarsAsync();

    }
}
