using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels
{
    public class PaymentValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (targetType != typeof(string)) throw new NotImplementedException();
            var grosze = Int32.Parse(value.ToString());
            return String.Format("{0:C}", (double)grosze / 100);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
