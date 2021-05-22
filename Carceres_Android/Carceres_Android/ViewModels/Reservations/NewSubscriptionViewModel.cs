using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Carceres_Android.ViewModels.Cars;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Carceres_Android.ViewModels.Reservations
{
    public class NewSubscriptionViewModel : BaseViewModel
    {
        private Places place;
        private Car car;
        private DateTime end;

        public ObservableCollection<Places> Places { get; }
        public ObservableCollection<Car> Cars { get; }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public NewSubscriptionViewModel()
        {
            Places = new ObservableCollection<Places>();
            Cars = new ObservableCollection<Car>();
            SaveCommand = new Command(OnSave, ValidateState);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
            Task.Run(async () => await LoadCars());
            Task.Run(async () => await LoadPlaces());
        }

        public Places Place
        {
            get => place;
            set => SetProperty(ref place, value);
        }

        public Car Car
        {
            get => car;
            set => SetProperty(ref car, value);
        }

        public DateTime End
        {
            get => end;
            set => SetProperty(ref end, value);
        }

        private bool ValidateState()
        {
            return place != null && end != null && car != null;
        }


        public async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }


        private async void OnSave()
        {
            Subscription newSubscription = new Subscription()
            {

            };
            await SubscriptionsService.AddSubscriptionAsync(newSubscription);
            await Shell.Current.GoToAsync("..");
        }


        public async Task LoadCars()
        {
            IsBusy = true;
            try
            {

                Cars.Clear();

                var task1 = CarsService.GetCarsAsync();

                foreach (var car in await task1)
                {
                    Cars.Add(car);
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

        public async Task LoadPlaces()
        {
            IsBusy = true;
            try
            {

                Places.Clear();

                var task1 = PlacesService.GetPlacesAsync();

                foreach (var place in await task1)
                {
                    Places.Add(place);
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

    }
}
