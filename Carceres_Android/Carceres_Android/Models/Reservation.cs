using System;
using System.Collections.Generic;
using System.Text;

namespace Carceres_Android.Models
{
    public class Reservation
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int type { get; set; }
        public int car_id { get; set; }
        public int place_id { get; set; }

    }
}
