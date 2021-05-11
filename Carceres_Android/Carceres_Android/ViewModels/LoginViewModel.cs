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
        private string username = "";
        private string password = "";
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

    }
}
