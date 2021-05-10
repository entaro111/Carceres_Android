using System;
using System.Collections.Generic;
using System.Text;

namespace Carceres_Android.Models
{
    public class Payment
    {
        public string id { get; set; }
        public string paid_date { get; set; }
        public string paid_type { get; set; }
        public string paid { get; set; }
        public string price { get; set; }
        public string value { get; set; }
        public string sale_date { get; set; }
        public string subscription_id { get; set; }
        public string tax { get; set; }
    }
}
