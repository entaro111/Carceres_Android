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
        public Client client { get; set; }

        public class Client
        {
            public int id { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string phone { get; set; }
            public int user_id { get; set; }

        }
    }
}
