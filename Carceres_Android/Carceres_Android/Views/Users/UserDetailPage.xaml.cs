using Carceres_Android.ViewModels.Users;

using Xamarin.Forms;

namespace Carceres_Android.Views.Users
{

    public partial class UserDetailPage : ContentPage
    {
        public UserDetailPage()
        {
            InitializeComponent();
            BindingContext = new UserDetailViewModel();
        }
    }
}