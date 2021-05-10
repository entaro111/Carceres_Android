using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Users
{
    public class UsersList : IUsersList<User>
    {
        readonly List<User> users;

        public UsersList()
        {
            users = new List<User>()
            {
                new User { id = Guid.NewGuid().ToString(), username = "Test1", userType = "Administrator" },
                new User { id = Guid.NewGuid().ToString(), username = "Test2", userType = "Klient" },
                new User { id = Guid.NewGuid().ToString(), username = "Test3", userType = "Bot" }
            };
        }
        public async Task<bool> AddUserAsync(User user)
        {
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var oldUser = users.Where((User arg) => arg.id == user.id).FirstOrDefault();
            users.Remove(oldUser);
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var oldUser = users.Where((User arg) => arg.id == id).FirstOrDefault();
            users.Remove(oldUser);

            return await Task.FromResult(true);
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.id == id));
        }

        public async Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }
    }
}
            
