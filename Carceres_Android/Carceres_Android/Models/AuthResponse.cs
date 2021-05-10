using System;
using System.Collections.Generic;
using System.Text;

namespace Carceres_Android.Models
{
    public class AuthResponse
    {
        public AuthResponse() { }

        public string access_token { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
    }
}
