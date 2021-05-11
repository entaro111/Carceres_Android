using Carceres_Android.Models;
using Carceres_Android.Services.Cars;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Cars
{

    [QueryProperty(nameof(CarId), nameof(CarId))]
    public class CarDetailViewModel : BaseViewModel
    {
        private string carId;
        private string plate;
        private string brand;

        //public string Id { get; set; }

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
        
        public string CarId
        {
            get => carId;
            set => SetProperty(ref carId, value);
        }
        /*
        public async void LoadCarId(string userId)
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
        */
    }

}
