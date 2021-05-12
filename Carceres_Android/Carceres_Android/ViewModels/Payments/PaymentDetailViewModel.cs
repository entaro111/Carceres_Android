using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Payments
{
    [QueryProperty(nameof(PaymentId), nameof(PaymentId))]
    public class PaymentDetailViewModel : BaseViewModel
    {
        private string paymentId;
        private string paid_date;
        private string value;

        //public string Id { get; set; }

        public string PaidDate
        {
            get => paid_date;
            set => SetProperty(ref paid_date, value);
        }

        public string Value
        {
            get => value;
            set => SetProperty(ref value, value);
        }

        public string PaymentId
        {
            get => paymentId;
            set => SetProperty(ref paymentId, value);
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
