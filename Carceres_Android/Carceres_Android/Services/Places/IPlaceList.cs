using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Places
{
    public interface IPlaceList<T>
    {
        Task<List<T>> GetPlacesAsync();
    }
}
