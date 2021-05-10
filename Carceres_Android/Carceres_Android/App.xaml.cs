using Carceres_Android.Services;
using Carceres_Android.Services.Cars;
using Carceres_Android.Services.Users;
using Carceres_Android.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<UsersList>();
            DependencyService.Register<CarsList>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
