using Carceres_Android.ViewModels.Cars;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android.Views.Cars
{
   
    public partial class CarsPage : ContentPage
    {
        CarsViewModel _viewModel;

        public CarsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CarsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
