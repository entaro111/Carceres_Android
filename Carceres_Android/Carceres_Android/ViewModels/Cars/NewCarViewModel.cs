using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Cars
{
   public class NewCarViewModel : BaseViewModel
    {
        
        private string plate;
        private string brand;
        private int client_id;

        public NewCarViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateState);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateState()
        {
            return !String.IsNullOrWhiteSpace(plate) && !String.IsNullOrWhiteSpace(brand) && (client_id != 0);
        }

        public string Plate
        {
            get => plate;
            set => SetProperty(ref plate, value);
        }

        public string Brand
        {
            get => brand;
            set => SetProperty(ref brand, value);
        }

        public int ClientId
        {
            get => client_id;
            set => SetProperty(ref client_id, value);
        }
        public Command SaveCommand { get; }

        public Command CancelCommand { get; }

        public async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
        
        private async void OnSave()
        {
            Car newCar = new Car()
            {
                
                plate = Plate,
                brand = Brand,
                client_id = ClientId
            };
            await CarsList.AddCarAsync(newCar);
            await Shell.Current.GoToAsync("..");

        }
        
    }
}
