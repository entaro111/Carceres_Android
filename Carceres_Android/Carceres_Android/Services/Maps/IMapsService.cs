using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Maps
{
    public interface IMapsService<T>
    {
        Task<IList<T>> GetZonesAsync();
    }
}
