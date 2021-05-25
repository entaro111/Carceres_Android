using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Payments
{
    [QueryProperty(nameof(PaymentId), nameof(PaymentId))]
    public class PaymentDetailViewModel : BaseViewModel
    {
        public Command SaveCommand { get; }
        private string paymentId;
        private string carBrand;
        private string carPlate;
        private DateTime reservationStart;
        private DateTime reservationEnd;
        private int prize;
        private string zoneName;
        private int placeNr;
        private bool paid;

        public PaymentDetailViewModel()
        {
            Title = "Szczegóły płatności";
            SaveCommand = new Command(OnSave, ValidateState);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }
        private bool ValidateState()
        {
            return !paid;
        }
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
        public DateTime ReservationStart
        {
            get => reservationStart;
            set => SetProperty(ref reservationStart, value);
        }
        public DateTime ReservationEnd
        {
            get => reservationEnd;
            set => SetProperty(ref reservationEnd, value);
        }
        public int Prize
        {
            get => prize;
            set => SetProperty(ref prize, value);
        }
        public string ZoneName
        {
            get => zoneName;
            set => SetProperty(ref zoneName, value);
        }
        public int PlaceNr
        {
            get => placeNr;
            set => SetProperty(ref placeNr, value);
        }
        public bool Paid
        {
            get => paid;
            set => SetProperty(ref paid, value);
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
                var subscription = await SubscriptionsService.GetSubscriptionAsync(payment.subscription_id.ToString());
                var zone = await ZonesService.GetZoneAsync(subscription.place.zone_id.ToString());
                Prize = payment.value;
                PlaceNr = subscription.place.nr;
                ZoneName = zone.name;
                ReservationStart = subscription.start;
                ReservationEnd = subscription.end;
                CarBrand = subscription.car.brand;
                CarPlate = subscription.car.plate;
                Paid = payment.paid;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("BŁĄD", "Nie wczytano danych płatności", "ANULUJ");
            }
        }

        private async void OnSave()
        {

            var response = await PaymentsService.UpdatePaymentAsync(PaymentId);
            if(response)
            {
                await Application.Current.MainPage.DisplayAlert("OK", "Opłacono", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("BŁĄD", "Nie udało się opłacić", "ANULUJ");
            }

        }

    }
}
