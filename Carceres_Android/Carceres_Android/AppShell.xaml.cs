using Carceres_Android.ViewModels;
using Carceres_Android.Views;
using Carceres_Android.Views.Cars;
using Carceres_Android.Views.Clients;
using Carceres_Android.Views.Payments;
using Carceres_Android.Views.Reservations;
//using Carceres_Android.Views.Users;
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

            Routing.RegisterRoute(nameof(CarDetailPage), typeof(CarDetailPage));
            Routing.RegisterRoute(nameof(ClientDetailPage), typeof(ClientDetailPage));
            Routing.RegisterRoute(nameof(PaymentDetailPage), typeof(PaymentDetailPage));
            Routing.RegisterRoute(nameof(SubscriptionDetailPage), typeof(SubscriptionDetailPage));
            Routing.RegisterRoute(nameof(NewSubscriptionPage), typeof(NewSubscriptionPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
