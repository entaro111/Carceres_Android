using Carceres_Android.Models;
using Carceres_Android.Services.API;
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
        private string username = "admin";
        private string password = "carceres";
        public Command LoginCommand { get; }

        public IRestService RestService => DependencyService.Get<IRestService>();

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            
        }

        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private async void OnLoginClicked(object obj)
        {
            {

                try
                {
                    IsBusy = true;

                    var response = await RestService.AuthWithCredentialsAsync(Username, Password);

                    if (response.Success)
                    {
                        await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("error", "Invalid Credentials", "CANCEL");
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    IsBusy = false;
                }

            }
        }
        /*
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
            
        }
        */
    }
}
