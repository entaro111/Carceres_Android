using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Cars
{
    [QueryProperty(nameof(CarId), nameof(CarId))]
    public class UpdateCarViewModel : BaseViewModel
    {
        private string carId;
        private string plate;
        private string brand;
        private int client_id;

        public UpdateCarViewModel()
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

        public int Id { get; set; }
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

        public string CarId
        {
            get { return carId; }
            set
            {
                carId = value;
                LoadCarId(value);
            }
        }
        public async void LoadCarId(string carId)
        {
            try
            {
                var car = await CarsList.GetCarAsync(carId);
                Id = car.id;
                Plate = car.plate;
                Brand = car.brand;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load User");
            }
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
            await CarsList.UpdateCarAsync(carId,newCar);
            await Shell.Current.GoToAsync("..");

        }
    }
}
