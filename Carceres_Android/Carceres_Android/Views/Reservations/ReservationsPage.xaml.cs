using Carceres_Android.ViewModels.Reservations;

using Xamarin.Forms;

namespace Carceres_Android.Views.Reservations
{
    public partial class ReservationsPage : ContentPage      
    {
        ReservationsViewModel _viewModel;
        public ReservationsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ReservationsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}