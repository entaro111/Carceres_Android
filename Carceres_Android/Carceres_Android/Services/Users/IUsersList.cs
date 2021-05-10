using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Users
{
    public interface IUsersList<T>
    {

        Task<bool> AddUserAsync(T user);
        Task<bool> UpdateUserAsync(T user);
        Task<bool> DeleteUserAsync(string id);
        Task<T> GetUserAsync(string id);
        Task<IEnumerable<T>> GetUsersAsync(bool forceRefresh = false);
    }
}
