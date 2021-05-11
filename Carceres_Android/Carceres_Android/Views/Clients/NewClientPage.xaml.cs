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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewClientPage : ContentPage
    {
        public NewClientPage()
        {
            InitializeComponent();
            BindingContext = new NewClientViewModel();
        }
    }
}