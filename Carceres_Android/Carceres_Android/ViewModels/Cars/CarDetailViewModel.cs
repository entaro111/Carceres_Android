using Carceres_Android.Views.Cars;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using static Carceres_Android.Models.Car;

namespace Carceres_Android.ViewModels.Cars
{

    [QueryProperty(nameof(CarId), nameof(CarId))]
    public class CarDetailViewModel : BaseViewModel
    {
        private string carId;
        private string plate;
        private string brand;
        private string clientName;
        private string clientSurname;

        public CarDetailViewModel()
        {

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
        
        public string ClientName
        {
            get => clientName;
            set => SetProperty(ref clientName, value);
        }

        public string ClientSurname
        {
            get => clientSurname;
            set => SetProperty(ref clientSurname, value);
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
                ClientName = car.client.name;
                ClientSurname = car.client.surname;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load User");
            }
        }

    }

}
