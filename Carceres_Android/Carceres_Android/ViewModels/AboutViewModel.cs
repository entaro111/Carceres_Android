using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Carceres";
            
        }
    }
}