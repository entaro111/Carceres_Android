using Carceres_Android.Models;
using Carceres_Android.Services.Payments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Payments
{
    public class PaymentsViewModel : BaseViewModel
    {
        public ObservableCollection<Payment> Payments { get; }
        public Command LoadPaymentsCommand { get; }

        public IPaymentsList PaymentsService => DependencyService.Get<IPaymentsList>();

        public PaymentsViewModel()
        {
            Title = "Płatności";
            Payments = new ObservableCollection<Payment>();
            LoadPaymentsCommand = new Command(ExecuteLoadPaymentsCommand);


        }

        private async void ExecuteLoadPaymentsCommand(object obj)
        {
            IsBusy = true;
            try
            {

                Payments.Clear();

                var task1 = PaymentsService.GetPaymentsAsync();

                foreach (var payment in await task1)
                {
                    Payments.Add(payment);
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
