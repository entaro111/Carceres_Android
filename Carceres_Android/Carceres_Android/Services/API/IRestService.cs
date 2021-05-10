using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.API
{
    public interface IRestService
    {
        string accessToken { get; }

        string RefreshToken { get; }


        Task<AuthResponse> AuthWithCredentialsAsync(string username, string password);
        Task<TResponse> ExecuteWithRetryAsync<TResponse>(Func<Task<TResponse>> method);
    }
}
