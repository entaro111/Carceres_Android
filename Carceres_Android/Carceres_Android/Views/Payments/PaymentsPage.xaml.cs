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
    public partial class PaymentsPage : ContentPage
    {
        PaymentsViewModel _viewModel;
        public PaymentsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PaymentsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}