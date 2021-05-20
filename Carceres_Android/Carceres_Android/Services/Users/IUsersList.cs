﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Users
{
    public interface IUsersList<T>
    {
        Task<bool> UpdateUserAsync(T user);
        Task<T> GetUserAsync();
    }
}
