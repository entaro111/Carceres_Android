﻿using Carceres_Android.Models;
using Carceres_Android.Services.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.Services.Users
{
    public class UsersList : IUsersList<User>
    {

        //private const string URL = "http://10.0.2.2:43343/api/user";
        public IRestService RestService => DependencyService.Get<IRestService>();

        public UsersList()
        {

        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            using (var client = new HttpClient())
            {
                string URL = "http://10.0.2.2:43343/api/user";
                client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync(URL, content);
                responseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<Car>(jsonResponse);
                return await Task.FromResult(true);

            };
        }

        public async Task<User> GetUserAsync()
        {

                using (var client = new HttpClient())
                {
                    string URL = "http://10.0.2.2:43343/api/user";
                     client.DefaultRequestHeaders.Add("x-access-tokens", RestService.accessToken);
                    var responseMessage = await client.GetAsync(URL);
                    responseMessage.EnsureSuccessStatusCode();
                    var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<User>(jsonResponse);
                    return response;
                }
        }
    }
}

