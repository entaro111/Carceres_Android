using System;
using System.Collections.Generic;
using System.Text;

namespace Carceres_Android.Models
{
    public class Reservation
    {
        public string id { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string type { get; set; }
        public string car_id { get; set; }
        public string place_id { get; set; }

    }
}
