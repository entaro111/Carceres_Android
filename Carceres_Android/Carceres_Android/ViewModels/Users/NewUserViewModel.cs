using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Users
{
    public class NewUserViewModel : BaseViewModel
    {
        private string username;
        private string userType;

        public NewUserViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateState);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateState()
        {
            return !String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(userType);
        }

        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string UserType
        {
            get => userType;
            set => SetProperty(ref userType, value);
        }

        public Command SaveCommand { get; }

        public Command CancelCommand { get; }

        public async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            User newUser = new User()
            {
                id = Guid.NewGuid().ToString(),
                username = username,
                user_type = UserType
            };
            await UserList.AddUserAsync(newUser);
            await Shell.Current.GoToAsync("..");
            
        }
    }
}
