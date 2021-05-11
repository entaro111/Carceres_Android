using Carceres_Android.ViewModels.Clients;

using Xamarin.Forms;

namespace Carceres_Android.Views.Clients
{
    
    public partial class ClientsPage : ContentPage
    {
        ClientsViewModel _viewModel;
        public ClientsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ClientsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}