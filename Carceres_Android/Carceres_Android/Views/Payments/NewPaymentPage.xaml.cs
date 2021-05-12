using Carceres_Android.Models;
using Carceres_Android.ViewModels.Payments;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android.Views.Payments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPaymentPage : ContentPage
    {
        public Payment Payment { get; set; }
        public NewPaymentPage()
        {
            InitializeComponent();
            BindingContext = new NewPaymentsViewModel();
        }
    }
}