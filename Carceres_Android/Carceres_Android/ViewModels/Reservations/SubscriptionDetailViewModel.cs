using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Reservations
{
    [QueryProperty(nameof(SubscriptionId), nameof(SubscriptionId))]
    public class SubscriptionDetailViewModel : BaseViewModel
    {
        private string subscriptionId;
        private string carBrand;
        private string carPlate;
        private DateTime reservationStart;
        private DateTime reservationEnd;
        private string zoneName;
        private int placeNr;
        private bool paid;

        public SubscriptionDetailViewModel()
        {
            Title = "Szczegóły rezerwacji";
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

        public string SubscriptionId
        {
            get { return subscriptionId; }
            set 
            {
                subscriptionId = value;
                LoadSubscriptionId(value);
            } 
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

        public int PlaceNr
        {
            get => placeNr;
            set => SetProperty(ref placeNr, value);
        }
        public string ZoneName
        {
            get => zoneName;
            set => SetProperty(ref zoneName, value);
        }
        public bool Paid
        {
            get => paid;
            set => SetProperty(ref paid, value);
        }

        public async void LoadSubscriptionId(string subscriptionId)
        {
            try
            {
                var subscription = await SubscriptionsService.GetSubscriptionAsync(subscriptionId);
                var zone = await ZonesService.GetZoneAsync(subscription.place.zone_id.ToString());
                PlaceNr = subscription.place.nr;
                ZoneName = zone.name;
                ReservationStart = subscription.start;
                ReservationEnd = subscription.end;
                CarBrand = subscription.car.brand;
                CarPlate = subscription.car.plate;
                Paid = subscription.payment.paid;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Subscription");
                await Application.Current.MainPage.DisplayAlert("BŁĄD", "Nie udało się wczytać danych subskrypcji", "ANULUJ");
            }
        }
        
    }
}
