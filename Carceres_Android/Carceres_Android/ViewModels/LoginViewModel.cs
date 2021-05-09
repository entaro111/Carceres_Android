using Carceres_Android.Models;
using Carceres_Android.Views;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        string text;

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            
        }

        private async void OnLoginClicked(object obj)
        {
            text = await Read();
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }


        public async Task<string> Read()
        {
            string test = "";
            var client = new RestClient("http://10.0.2.2:43343");
            client.Authenticator = new HttpBasicAuthenticator("admin", "carceres");
            var request = new RestRequest("/api/login");

            var response = client.Get(request);

            if(response.ResponseStatus == ResponseStatus.Completed)
            {
                var authResponse = JsonConvert.DeserializeObject<AuthResponse>(response.Content);
                Preferences.Set("BearerToken", authResponse.access_token);
            }
            
            return test;
            /*
            HttpClient client = new HttpClient();
            Uri uri = new Uri(string.Format("http://10.0.2.2:43343/api/login", string.Empty));
            
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return text;
            */
        }
    }
}
