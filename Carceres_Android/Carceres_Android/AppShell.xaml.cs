using Carceres_Android.ViewModels;
using Carceres_Android.Views;
using Carceres_Android.Views.Users;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Carceres_Android
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(UserDetailPage), typeof(UserDetailPage));
            Routing.RegisterRoute(nameof(NewUserPage), typeof(NewUserPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
