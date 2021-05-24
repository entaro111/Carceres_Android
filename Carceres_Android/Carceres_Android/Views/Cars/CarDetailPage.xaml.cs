using Carceres_Android.ViewModels.Cars;

using Xamarin.Forms;

namespace Carceres_Android.Views.Cars
{
    public partial class CarDetailPage : ContentPage
    {
     //   public Models.Clients client { get; set; }
        public CarDetailPage()
        {
            InitializeComponent();
            BindingContext = new CarDetailViewModel();
        }
    }
}