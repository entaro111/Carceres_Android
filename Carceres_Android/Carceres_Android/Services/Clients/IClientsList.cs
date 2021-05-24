using System.Threading.Tasks;

namespace Carceres_Android.Services.Clients
{
    public interface IClientsList<T>
    {
        Task<T> GetClientAsync();

        Task<bool> UpdateClientAsync(Models.Clients client);
    }
}
