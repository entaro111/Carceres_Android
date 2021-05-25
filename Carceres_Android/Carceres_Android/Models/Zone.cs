using System;
using System.Collections.Generic;
using System.Text;

namespace Carceres_Android.Models
{
    public class Zone
    {
        public Zone() { }
        public int id { get; set; }
        public string name { get; set; }
        public string bkg_file { get; set; }
        public List<Places> places { get; set; }
    }
}
