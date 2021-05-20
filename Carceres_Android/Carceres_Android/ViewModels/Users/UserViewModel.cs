using Carceres_Android.Models;
using Carceres_Android.Services.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Users
{
    public class UserViewModel : BaseViewModel
    {
        public StackLayout stack = new StackLayout();

        private string name;
        private string surname;
        private int user_type;

        private string greeting;

        public UserViewModel()
        {
            Title = "Carceres";
        }



        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }

        public int UserType
        {
            get => user_type;
            set => SetProperty(ref user_type, value);
        }

        public string Greeting
        {
            get => greeting;
            set => SetProperty(ref greeting, value);
        }

        public async void LoadUser()
        {
            IsBusy = true;
            try
            {
                var user = await UsersList.GetUserAsync();

                Name = user.client.name;
                Surname = user.client.surname;
                UserType = user.user_type;

                if (Name != null) Greeting = "Witaj " + Name + "!";
                else Greeting = "Witaj nieznajomy";
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load User");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            LoadUser();
        }
    }
}
