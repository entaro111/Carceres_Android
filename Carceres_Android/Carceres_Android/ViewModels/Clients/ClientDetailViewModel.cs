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
            SaveCommand = new Command(OnSave, ValidateState);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public Command SaveCommand { get; }

        public Command CancelCommand { get; }

        private string name;
        private string surname;
        private string address;
        private string city;
        private string phone;

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
        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }
        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

        public async Task LoadClient()
        {
            try
            {
                var client = await ClientService.GetClientAsync();
                Name = client.name;
                Surname = client.surname;
                Address = client.address;
                City = client.city;
                Phone = client.phone;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("BŁĄD", "Nie udało się załadować danych", "ANULUJ");
            }
        }

        private bool ValidateState()
        {
            return !String.IsNullOrWhiteSpace(name) && !String.IsNullOrWhiteSpace(surname);
        }

        public async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {


            Models.Clients updatedClient = new Models.Clients()
            {

                name = Name,
                surname = Surname,
                address = Address,
                city = City,
                phone = Phone

            };
            var response = await ClientService.UpdateClientAsync(updatedClient);
            if (response)
            {
                await Application.Current.MainPage.DisplayAlert("OK", "Zaktualizowano dane", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("BŁĄD", "Nie udało się zaktualizować danych", "ANULUJ");
            }

        }
    }

}
