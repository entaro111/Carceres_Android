using Carceres_Android.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Carceres_Android.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}