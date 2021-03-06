using Carceres_Android.Models;
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
        public ObservableCollection<Car> Cars { get; }
        public Command LoadCarsCommand { get; }

        public CarsViewModel()
        {
            Title = "Samochody klienta";
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
        public void OnAppearing()
        {
            IsBusy = true;
        }

    }
}
