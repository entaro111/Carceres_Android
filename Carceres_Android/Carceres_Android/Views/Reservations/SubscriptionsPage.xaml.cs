using Carceres_Android.ViewModels.Reservations;

using Xamarin.Forms;

namespace Carceres_Android.Views.Reservations
{
    public partial class SubscriptionsPage : ContentPage      
    {
        SubscriptionsViewModel _viewModel;
        public SubscriptionsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SubscriptionsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}