using Carceres_Android.Models;
using Carceres_Android.Services;
using Carceres_Android.Services.Cars;
using Carceres_Android.Services.Maps;
using Carceres_Android.Services.Payments;
using Carceres_Android.Services.Reservations;
using Carceres_Android.Services.Places;
using Carceres_Android.Services.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public IUsersList<User> UsersList => DependencyService.Get<IUsersList<User>>();
        public ICarsList<Car> CarsList => DependencyService.Get<ICarsList<Car>>();
        public IPaymentsList<Payment> PaymentsService => DependencyService.Get<IPaymentsList<Payment>>();
        public ISubscriptionsList<Subscription> SubscriptionsService => DependencyService.Get<ISubscriptionsList<Subscription>>();
        public IMapsService<Zone> ZonesService => DependencyService.Get<IMapsService<Zone>>();
        public ICarsList<Car> CarsService => DependencyService.Get<ICarsList<Car>>();
        public IPlaceList<Models.Places> PlacesService => DependencyService.Get<IPlaceList<Models.Places>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set 
            {
                SetProperty(ref isBusy, value);
                SetProperty(ref isBusy, value, nameof(IsNotBusy)); 
            }
        }

        public bool IsNotBusy
        {
            get { return !IsBusy; }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
