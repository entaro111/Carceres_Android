using Carceres_Android.Models;
using Carceres_Android.ViewModels.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android.Views.Reservations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewSubscriptionPage : ContentPage
    {
        public Subscription Subscription { get; set; }

        NewSubscriptionViewModel _viewModel;
        DateTime dt = new DateTime();
        public NewSubscriptionPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewSubscriptionViewModel();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void CarSelectedChanged(object sender, EventArgs e)
        {
            _viewModel.Car = (Car)CarPicker.SelectedItem;
        }

        private void PlaceSelectedChanged(object sender, EventArgs e)
        {
            _viewModel.Place = (Places)PlacePicker.SelectedItem;
        }

        private void DateSelectedChanged(object sender, EventArgs e)
        {

            dt = DatePicker.Date;
            dt = dt.ToUniversalTime();
            _viewModel.End = dt;
        }

    }
}