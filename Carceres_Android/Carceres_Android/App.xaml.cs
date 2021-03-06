using Carceres_Android.Services;
using Carceres_Android.Services.API;
using Carceres_Android.Services.Cars;
using Carceres_Android.Services.Clients;
using Carceres_Android.Services.Maps;
using Carceres_Android.Services.Payments;
using Carceres_Android.Services.Places;
using Carceres_Android.Services.Reservations;
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

            DependencyService.Register<UsersList>();
            DependencyService.Register<CarsList>();
            DependencyService.Register<ClientsList>();
            DependencyService.Register<PaymentsList>();
            DependencyService.Register<SubscriptionsList>();
            DependencyService.Register<MapsService>();
            DependencyService.Register<IRestService, RestService>();
            DependencyService.Register<PlaceList>();
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
