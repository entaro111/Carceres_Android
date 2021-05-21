using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Payments
{
    [QueryProperty(nameof(PaymentId), nameof(PaymentId))]
    public class PaymentDetailViewModel : BaseViewModel
    {
        private string paymentId;
        private string carBrand;
        private string carPlate;
        private string reservationStart;
        private string reservationEnd;
        private int prize;

        public string CarBrand
        {
            get => carBrand;
            set => SetProperty(ref carBrand, value);
        }
        public string CarPlate
        {
            get => carPlate;
            set => SetProperty(ref carPlate, value);
        }
        public string ReservationStart
        {
            get => reservationStart;
            set => SetProperty(ref reservationStart, value);
        }
        public string ReservationEnd
        {
            get => reservationEnd;
            set => SetProperty(ref reservationEnd, value);
        }
        public int Prize
        {
            get => prize;
            set => SetProperty(ref prize, value);
        }
        public string PaymentId
        {
            get { return paymentId; }
            set
            {
                paymentId = value;
                LoadPaymentId(value);
            }
        }


        
        public async void LoadPaymentId(string paymentId)
        {
            try
            {
                var payment = await PaymentsService.GetPaymentAsync(paymentId);
                Prize = payment.price;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load User");
            }
        }
        
    }
}
