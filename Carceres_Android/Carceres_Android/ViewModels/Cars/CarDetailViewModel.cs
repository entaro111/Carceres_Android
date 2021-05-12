using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Cars
{

    [QueryProperty(nameof(CarId), nameof(CarId))]
    public class CarDetailViewModel : BaseViewModel
    {
        private string carId;
        private string plate;
        private string brand;

        public int? Id { get; set; }

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
        
        //public string CarId
        //{
        //    get => carId;
        //    set => SetProperty(ref carId, value);
        //}
        
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
        
    }

}
