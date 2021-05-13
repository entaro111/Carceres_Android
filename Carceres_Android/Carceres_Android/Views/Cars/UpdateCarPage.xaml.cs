using Carceres_Android.Models;
using Carceres_Android.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android.Views.Cars
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateCarPage : ContentPage
    {
        public Car Car { get; set; }
        public UpdateCarPage()
        {
            InitializeComponent();
            InitializeComponent();
            BindingContext = new UpdateCarViewModel();
        }
    }
}