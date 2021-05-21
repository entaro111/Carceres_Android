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
    public partial class SubscriptionDetailPage : ContentPage
    {
        public SubscriptionDetailPage()
        {
            InitializeComponent();
            BindingContext = new SubscriptionDetailViewModel();
        }
    }
}