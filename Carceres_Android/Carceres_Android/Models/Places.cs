using System;
using System.Collections.Generic;
using System.Text;

namespace Carceres_Android.Models
{
    public class Places
    {
        public int id { get; set; }
        public int nr { get; set; }
        public int zone_id { get; set; }

        public class Zone
        {
            public int id { get;  } 
            public string name { get; }
            public Uri uri = new Uri("zone");
        }
        public string name { get; set; }
        public float pos_x { get; set; }
        public float pos_y { get; set; }
        public bool occupied { get; set; }
    }
}
