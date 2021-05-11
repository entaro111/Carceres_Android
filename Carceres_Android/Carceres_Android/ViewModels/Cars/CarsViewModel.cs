using Carceres_Android.Models;
using Carceres_Android.Services.Cars;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Cars
{
    public class CarsViewModel : BaseViewModel
    {


        public ObservableCollection<Car> Cars { get; }
        public Command LoadCarsCommand { get; }

        public ICarsList CarsService => DependencyService.Get<ICarsList>();

        public CarsViewModel()
        {
            Title = "Samochody";
            Cars = new ObservableCollection<Car>();
            LoadCarsCommand = new Command(ExecuteLoadCarsCommand);


        }

        private async void ExecuteLoadCarsCommand(object obj)
        {
            IsBusy = true;

            try
            {
                Cars.Clear();

                var task1 = CarsService.GetCarsAsync();
                var task2 = CarsService.GetCarsAsync();
                var task3 = CarsService.GetCarsAsync();
                var task4 = CarsService.GetCarsAsync();

                foreach (var car in await task2)
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
        }
        
    }
}
