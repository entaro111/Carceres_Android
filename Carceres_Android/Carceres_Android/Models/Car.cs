using System;
using System.Collections.Generic;
using System.Text;

namespace Carceres_Android.Models
{
    public class Car
    {
        public Car()
        {

        }
        public int id { get; set; }
        public string plate { get; set; }
        public string brand { get; set; }
        public int client_id { get; set; }

        public Car(string pl, string br, int cid)
        {
            id = -1;
            plate = pl;
            brand = br;
            client_id = cid;
        }

    }
}
