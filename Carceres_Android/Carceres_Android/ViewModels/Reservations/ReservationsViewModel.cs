using Carceres_Android.Models;
using Carceres_Android.Services.Reservations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Reservations
{
    public class ReservationsViewModel : BaseViewModel
    {
        public ObservableCollection<Reservation> Reservations { get; }
        public Command LoadReservationsCommand { get; }

        public IReservationsList ReservationsService => DependencyService.Get<IReservationsList>();

        public ReservationsViewModel()
        {
            Title = "Rezerwacje";
            Reservations = new ObservableCollection<Reservation>();
            LoadReservationsCommand = new Command(ExecuteLoadReservationsCommand);


        }

        private async void ExecuteLoadReservationsCommand(object obj)
        {
            IsBusy = true;
            try
            {

                Reservations.Clear();

                var task1 = ReservationsService.GetReservationsAsync();

                foreach (var reservation in await task1)
                {
                    Reservations.Add(reservation);
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
