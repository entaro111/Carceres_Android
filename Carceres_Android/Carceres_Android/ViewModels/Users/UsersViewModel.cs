using Carceres_Android.Models;
using Carceres_Android.ViewModels.Users;
using Carceres_Android.Views.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private User _selectedUser;

        public ObservableCollection<User> Users { get; }
        public Command LoadUsersCommand { get; }
        public Command AddUserCommand { get; }
        public Command<User> UserTapped { get; }

        public UsersViewModel()
        {
            Title = "Uzytkownicy";
            Users = new ObservableCollection<User>();
            LoadUsersCommand = new Command(async () => await ExecuteLoadUsersCommand());
            UserTapped = new Command<User>(OnUserSelected);
            AddUserCommand = new Command(OnAddUser);
        }

        async Task ExecuteLoadUsersCommand()
        {
            IsBusy = true;
            try
            {
                Users.Clear();
                var users = await UserList.GetUsersAsync(true);
                foreach(var user in users)
                {
                    Users.Add(user);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedUser = null;
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                SetProperty(ref _selectedUser, value);
                OnUserSelected(value);
            }
        }

        private async void OnAddUser(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewUserPage));
        }

        async void OnUserSelected(User user)
        {
            if (user == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(UserDetailPage)}?{nameof(UserDetailViewModel.UserId)}={user.id}");
        }
    }
}
