using Carceres_Android.Models;
using Carceres_Android.Services.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Users
{
    public class UserDetailViewModel : BaseViewModel
    {
        public UserDetailViewModel()
        {
            Title = "Użytkownik";
            Task.Run(async () => await LoadUser());
            SaveCommand = new Command(OnSave, ValidateState);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public Command SaveCommand { get; }
        private string username;
        private string oldPassword;
        private string newPassword;
        private string retypedNewPassword;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string OldPassword
        {
            get => oldPassword;
            set => SetProperty(ref oldPassword, value);
        }
        public string NewPassword
        {
            get => newPassword;
            set => SetProperty(ref newPassword, value);
        }
        public string RetypedNewPassword
        {
            get => retypedNewPassword;
            set => SetProperty(ref retypedNewPassword, value);
        }


        public async Task LoadUser()
        {
            try
            {
                var user = await UsersList.GetUserAsync();
                Username = user.name;

            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("error", e.Message, "CANCEL");
            }
        }

        private bool ValidateState()
        {
            return !String.IsNullOrWhiteSpace(oldPassword) && !String.IsNullOrWhiteSpace(newPassword) && !String.IsNullOrWhiteSpace(retypedNewPassword)
                && newPassword == retypedNewPassword;

        }

        private async void OnSave()
        {
            RestService restService = new RestService();
            var response = await restService.AuthWithCredentialsAsync(Username, OldPassword);

            if (response.Success)
            {
                var responseUpdate = await UsersList.UpdateUserAsync(NewPassword);
                if (responseUpdate)
                {
                    await Application.Current.MainPage.DisplayAlert("OK", "Hasło zostało zmienione", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("BŁĄD", "Nie zmieniono hasła", "ANULUJ");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("BŁĄD", "Nieprawidłowe stare hasło", "ANULUJ");
            }

        }
    }
}
