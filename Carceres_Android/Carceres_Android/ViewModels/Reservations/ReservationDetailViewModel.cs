using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Reservations
{
    [QueryProperty(nameof(ReservationId), nameof(ReservationId))]
    public class ReservationDetailViewModel : BaseViewModel
    {
        private string reservationId;
        private string start;
        private string end;

        //public string Id { get; set; }

        public string Start
        {
            get => start;
            set => SetProperty(ref start, value);
        }

        public string End
        {
            get => end;
            set => SetProperty(ref end, value);
        }

        public string ReservationId
        {
            get => reservationId;
            set => SetProperty(ref reservationId, value);
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
