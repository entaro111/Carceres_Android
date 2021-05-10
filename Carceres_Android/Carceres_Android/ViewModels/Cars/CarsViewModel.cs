using Carceres_Android.Models;
using Carceres_Android.Views.Cars;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Cars
{
    class CarsViewModel : BaseViewModel
    {
        private Car _selectedCar;

        public ObservableCollection<Car> Cars { get; }
        public Command LoadCarsCommand { get; }
        public Command AddCarCommand { get; }
        public Command<Car> CarTapped { get; }

        public CarsViewModel()
        {
            Title = "Samochody";
            Cars = new ObservableCollection<Car>();
            LoadCarsCommand = new Command(async () => await ExecuteLoadCarsCommand());
            CarTapped = new Command<Car>(OnCarSelected);
            AddCarCommand = new Command(OnAddCar);
        }

        async Task ExecuteLoadCarsCommand()
        {
            IsBusy = true;
            try
            {
                Cars.Clear();
                var cars = await CarsList.GetCarsAsync(true);
                foreach (var car in cars)
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedCar = null;
        }

        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                SetProperty(ref _selectedCar, value);
                OnCarSelected(value);
            }
        }

        private async void OnAddCar(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewCarPage));
        }

        async void OnCarSelected(Car car)
        {
            if (car == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(CarDetailPage)}?{nameof(CarDetailViewModel.CarId)}={car.id}");
        }

    }
}
