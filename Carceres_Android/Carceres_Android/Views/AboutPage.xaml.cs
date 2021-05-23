using Carceres_Android.ViewModels.Users;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel _viewModel;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AboutViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            
        }
    }
}