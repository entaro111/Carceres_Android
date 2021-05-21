using Carceres_Android.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android.Services.Payments
{
    public interface IPaymentsList<T>
    {

        Task<List<T>> GetPaymentsAsync();

        Task<T> GetPaymentAsync(string id);
    }
}
