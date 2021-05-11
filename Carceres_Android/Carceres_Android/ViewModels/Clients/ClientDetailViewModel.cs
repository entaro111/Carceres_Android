using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Clients
{
    public class ClientDetailViewModel : BaseViewModel
    {
        [QueryProperty(nameof(ClientId), nameof(ClientId))]
        public class CarDetailViewModel : BaseViewModel
        {
            private string clientId;
            private string name;
            private string surname;

            //public string Id { get; set; }

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

            public string ClientId
            {
                get => clientId;
                set => SetProperty(ref clientId, value);
            }
            /*
            public async void LoadClientId(string clientId)
            {
                try
                {
                    var client = await ClientsList.GetClientAsync(clientId);
                    Id = client.id;
                    Name = client.name;
                    Surname = client.surname;
                }
                catch (Exception)
                {
                    Debug.WriteLine("Failed to Load User");
                }
            }
            */
        }
    }
}
