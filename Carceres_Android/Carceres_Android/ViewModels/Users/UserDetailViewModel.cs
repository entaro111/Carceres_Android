using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.ViewModels.Users
{
    public class UserDetailViewModel : BaseViewModel
    {
        public UserDetailViewModel()
        {
            Title = "Użytkownik";
            Task.Run(async () => await LoadUser());
        }

        private string name;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public async Task LoadUser()
        {
            try
            {
                var user = await UsersList.GetUserAsync();
                Name = user.name;
                
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load User");
            }
        }
    }
}
