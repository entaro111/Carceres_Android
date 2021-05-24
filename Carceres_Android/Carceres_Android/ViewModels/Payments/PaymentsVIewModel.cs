using Carceres_Android.Models;
using Carceres_Android.Services.Payments;
using Carceres_Android.Views.Payments;
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
        private Payment _selectedPayment;
        public ObservableCollection<Payment> Payments { get; }
        public Command LoadPaymentsCommand { get; }
        public Command<Payment> PaymentTapped { get; }

        public PaymentsViewModel()
        {
            Title = "Płatności";
            Payments = new ObservableCollection<Payment>();
            LoadPaymentsCommand = new Command(ExecuteLoadPaymentsCommand);
            PaymentTapped = new Command<Payment>(OnPaymentSelected);

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
                await Application.Current.MainPage.DisplayAlert("BŁĄD", "Nie wczytano płatności", "ANULUJ");
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedPayment = null;
        }

        public Payment SelectedPayment
        {
            get => _selectedPayment;
            set
            {
                SetProperty(ref _selectedPayment, value);
                OnPaymentSelected(value);
            }
        }

        async void OnPaymentSelected(Payment payment)
        {
            if (payment == null) return;
            await Shell.Current.GoToAsync($"{nameof(PaymentDetailPage)}?{nameof(PaymentDetailViewModel.PaymentId)}={payment.id}");
        }


    }
}
