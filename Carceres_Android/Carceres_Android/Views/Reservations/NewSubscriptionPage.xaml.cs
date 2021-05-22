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
        public NewSubscriptionPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewSubscriptionViewModel();
            
        }

    }
}