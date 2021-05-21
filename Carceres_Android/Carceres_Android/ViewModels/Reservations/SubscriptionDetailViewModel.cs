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
        private DateTime start;
        private string end;
        private string carBrand;
        private string carPlate;
        private string placeId;
        private string zoneName;

        public DateTime Start
        {
            get => start;
            set => SetProperty(ref start, value);
        }

        public string End
        {
            get => end;
            set => SetProperty(ref end, value);
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

        public string PlaceId
        {
            get => placeId;
            set => SetProperty(ref placeId, value);
        }
        public string ZoneName
        {
            get => zoneName;
            set => SetProperty(ref zoneName, value);
        }

        
        public async void LoadSubscriptionId(string subscriptionId)
        {
            try
            {
                var subscription = await SubscriptionsService.GetSubscriptionAsync(subscriptionId);
                Start = subscription.start;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Subscription");
            }
        }
        
    }
}
