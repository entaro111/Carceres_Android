using System;
using System.Collections.Generic;
using System.Text;

namespace Carceres_Android.Models
{
    public class Payment
    {
        public int id { get; set; }
        public DateTime paid_date { get; set; }
        public int paid_type { get; set; }
        public bool paid { get; set; }
        public int price { get; set; }
        public int value { get; set; }
        public DateTime sale_date { get; set; }
        public int subscription_id { get; set; }
        public int tax { get; set; }
    }
}
