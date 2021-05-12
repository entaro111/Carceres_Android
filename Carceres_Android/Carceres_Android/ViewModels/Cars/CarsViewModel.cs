﻿using Carceres_Android.Models;
using Carceres_Android.Services.Cars;
using Carceres_Android.Views.Cars;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Cars
{
    public class CarsViewModel : BaseViewModel
    {
        private Car _selectedCar;
        public ObservableCollection<Car> Cars { get; }
        public Command LoadCarsCommand { get; }
        public Command AddCarCommand { get; }
        public Command<Car> CarTapped { get; }
        public ICarsList<Car> CarsService => DependencyService.Get<ICarsList<Car>>();

        public CarsViewModel()
        {
            Title = "Samochody";
            Cars = new ObservableCollection<Car>();
            LoadCarsCommand = new Command(ExecuteLoadCarsCommand);
            CarTapped = new Command<Car>(OnCarSelected);
            AddCarCommand = new Command(OnAddCar);
        }

        private async void ExecuteLoadCarsCommand(object obj)
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

        async void OnCarSelected(Car car)
        {
            if (car == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(CarDetailPage)}?{nameof(CarDetailViewModel.CarId)}={car.id}");
        }

        private async void OnAddCar(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewCarPage));
        }
    }
}
