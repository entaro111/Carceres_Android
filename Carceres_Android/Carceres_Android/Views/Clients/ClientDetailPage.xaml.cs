using Carceres_Android.ViewModels.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android.Views.Clients
{
    public partial class ClientDetailPage : ContentPage
    {
        public ClientDetailPage()
        {
            InitializeComponent();
            BindingContext = new ClientDetailViewModel();
        }
    }
}