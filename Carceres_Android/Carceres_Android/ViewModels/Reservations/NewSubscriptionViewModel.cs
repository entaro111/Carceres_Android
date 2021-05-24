using Carceres_Android.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            set
            {
                if (place != value)
                {
                    SetProperty(ref place, value);
                    OnPropertyChanged();
                }
            }
        }

        public Car Car
        {
            get => car;
            set
            {
                if(car != value)
                {
                    SetProperty(ref car, value);
                    OnPropertyChanged();
                }
            }
        }

        public DateTime End
        {
            get => end;
            set
            {
                if (end != value)
                {
                    SetProperty(ref end, value);
                    OnPropertyChanged();
                }
            }
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
                car_id = Car.id,
                place_id = Place.id,
                end = End
            };
            var response = await SubscriptionsService.AddSubscriptionAsync(newSubscription);
            if (response)
            {
                await Application.Current.MainPage.DisplayAlert("OK", "Dodano rezerwację", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("BŁĄD", "Nie udało się dodać rezerwacji", "ANULUJ");
            }
            
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
                await Application.Current.MainPage.DisplayAlert("BŁĄD", "Nie udało się wczytać samochodów", "ANULUJ");
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
                    if(!place.occupied) Places.Add(place);

                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Application.Current.MainPage.DisplayAlert("BŁĄD", "Nie udało się wczytać miejsc", "ANULUJ");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
