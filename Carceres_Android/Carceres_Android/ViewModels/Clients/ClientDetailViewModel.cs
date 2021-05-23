using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Clients
{
     public class ClientDetailViewModel : BaseViewModel
    {
        public ClientDetailViewModel()
        {
            Title = "Klient";
            Task.Run(async () => await LoadClient());
        }

        private string name;
        private string surname;


        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }

        public async Task LoadClient()
        {
            try
            {
                var client = await ClientService.GetClientAsync();
                Name = client.name;
                Surname = client.surname;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load User");
            }
        }
    }

}
