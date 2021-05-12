using Carceres_Android.ViewModels.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android.Views.Payments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentDetailPage : ContentPage
    {
        public PaymentDetailPage()
        {
            InitializeComponent();
            BindingContext = new PaymentDetailViewModel();
        }
    }
}