using Carceres_Android.Models;
using Carceres_Android.ViewModels.Cars;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android.Views.Cars
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCarPage : ContentPage
    {
        public Car Car { get; set; }
        public NewCarPage()
        {
            InitializeComponent();
            BindingContext = new NewCarViewModel();
        }
    }
}