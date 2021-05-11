using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Clients
{
    public interface IClientsList
    {
        Task<IList<Client>> GetClientsAsync();
    }
}
