using Carceres_Android.ViewModels.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android.Views.Map
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InteractiveMap : ContentPage
    {

        InteractiveMapsViewModel _viewModel;
        public InteractiveMap()
        {
            InitializeComponent();
            BindingContext = _viewModel = new InteractiveMapsViewModel();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}