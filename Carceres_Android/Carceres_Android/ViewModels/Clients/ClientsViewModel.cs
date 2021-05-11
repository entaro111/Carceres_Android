using Carceres_Android.Models;
using Carceres_Android.Services.Clients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Clients
{
    public class ClientsViewModel : BaseViewModel
    {
        public ObservableCollection<Client> Clients { get; }
        public Command LoadClientsCommand { get; }

        public IClientsList ClientsService => DependencyService.Get<IClientsList>();

        public ClientsViewModel()
        {
            Title = "Klienci";
            Clients = new ObservableCollection<Client>();
            LoadClientsCommand = new Command(ExecuteLoadClientsCommand);


        }

        private async void ExecuteLoadClientsCommand(object obj)
        {
            IsBusy = true;
            try
            {

                Clients.Clear();

                var task1 = ClientsService.GetClientsAsync();

                foreach (var client in await task1)
                {
                    Clients.Add(client);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
