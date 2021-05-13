using System;
using System.Collections.Generic;
using System.Text;

namespace Carceres_Android.Models
{
    public class Zone
    {
        public int id { get; set; }
        public string name { get; set; }

        public string bkg_file { get; set; }

        private class Place
        {
            public int id { get; }
            public int nr { get; }
            public int zone_id { get; }
            public string name { get; }
            public float pos_x { get; }
            public float pos_y { get; }
            public bool occupied { get; }
        }
    }
}
