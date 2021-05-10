using Carceres_Android.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android.Views.Users
{
    public partial class UsersPage : ContentPage
    {
        UsersViewModel _viewModel;

        public UsersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new UsersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}