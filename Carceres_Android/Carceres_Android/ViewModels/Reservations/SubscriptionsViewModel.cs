using Carceres_Android.Models;
using Carceres_Android.Services.Reservations;
using Carceres_Android.Views.Reservations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Reservations
{
    public class SubscriptionsViewModel : BaseViewModel
    {
        private Subscription _selectedSubscription;
        public ObservableCollection<Subscription> Subscriptions { get; }
        public Command LoadSubscriptionsCommand { get; }
        public Command<Subscription> SubscriptionTapped { get; }
        public Command AddSubscriptionCommand { get; }
        public SubscriptionsViewModel()
        {
            Title = "Rezerwacje";
            Subscriptions = new ObservableCollection<Subscription>();
            LoadSubscriptionsCommand = new Command(ExecuteLoadSubscriptionsCommand);
            SubscriptionTapped = new Command<Subscription>(OnSubscriptionSelected);
            AddSubscriptionCommand = new Command(OnAddSubscription);
        }

        private async void ExecuteLoadSubscriptionsCommand(object obj)
        {
            IsBusy = true;
            try
            {

                Subscriptions.Clear();

                var task1 = SubscriptionsService.GetSubscriptionsAsync();

                foreach (var subscription in await task1)
                {
                    Subscriptions.Add(subscription);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedSubscription = null;
        }

        public Subscription SelectedSubscription
        {
            get => _selectedSubscription;
            set
            {
                SetProperty(ref _selectedSubscription, value);
                OnSubscriptionSelected(value);
            }
        }

        async void OnSubscriptionSelected(Subscription subscription)
        {
            if (subscription == null) return;
            await Shell.Current.GoToAsync($"{nameof(SubscriptionDetailPage)}?{nameof(SubscriptionDetailViewModel.SubscriptionId)}={subscription.id}");
        }

        private async void OnAddSubscription()
        {
            await Shell.Current.GoToAsync(nameof(NewSubscriptionPage));
        }
    }
}
