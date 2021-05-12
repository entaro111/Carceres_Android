using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Reservations
{
    public interface IReservationsList
    {
        Task<IList<Reservation>> GetReservationsAsync();
    }
}
