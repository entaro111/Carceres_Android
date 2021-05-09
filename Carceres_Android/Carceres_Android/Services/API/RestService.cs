using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Carceres_Android
{
    class RestService
    {
        public static string RestUrl = "http://10.0.0.2";

        HttpClient client;      
        public string odpowiedz { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            
        }

        public async Task<string> TakeData()
        {
            
            Uri uri = new Uri(string.Format(RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return odpowiedz;
        }
    }
}
