using Carceres_Android.Models;
using Carceres_Android.ViewModels.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carceres_Android.Views.Users
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUserPage : ContentPage
    {
        public User User { get; set; }
        public NewUserPage()
        {
            InitializeComponent();
            BindingContext = new NewUserViewModel();
        }
    }
}