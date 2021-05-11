using Carceres_Android.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Carceres_Android.Services.API
{
    public class RestService : IRestService
    {
        

        public RestService() { }

        public HttpClient httpClient = new HttpClient();

        private static int _refreshTokenEntered = 0;

        public string accessToken => Preferences.Get("BearerToken", string.Empty);
        public string RefreshToken => Preferences.Get("RefreshToken", string.Empty);

        private const string REFRESH_TOKEN_URL = "http://10.0.2.2:43343/api/refresh";
        private const string AUTH_URL = "http://10.0.2.2:43343/api/login";

        public async Task<TResponse> ExecuteWithRetryAsync<TResponse>(Func<Task<TResponse>> webApiCallMethod)
        {
            var tryForceRefreshToken = false;
            var attemptsCounter = 1;
            while (true)
            {
                if (tryForceRefreshToken)
                {
                    var success = await TryAuthWithRefreshTokenAsync();
                }
                try
                {
                    attemptsCounter++;

                    var response = await webApiCallMethod.Invoke();
                    return response;
                }
                catch (HttpRequestException)
                {
                    if (attemptsCounter > 2)
                    {
                        throw;
                    }
                    tryForceRefreshToken = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        public async Task<AuthResponse> AuthWithCredentialsAsync(string username, string password)
        {
            HttpClientHandler handler = new HttpClientHandler();
            var byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var responseMessage = await httpClient.GetAsync(AUTH_URL);
            if (responseMessage.IsSuccessStatusCode)
            {
                var stringResponse = await responseMessage.Content.ReadAsStringAsync();
                var authResponse = JsonConvert.DeserializeObject<AuthResponse>(stringResponse);
                authResponse.Success = true;
                Preferences.Set("BearerToken", authResponse.access_token);
                Preferences.Set("RefreshToken", authResponse.RefreshToken);

                return authResponse;
            }
            else
            {
                return new AuthResponse();
            }
        }





        private async Task<bool> TryAuthWithRefreshTokenAsync()
        {
            try
            {
                //Tenta executar o refreshtoken apenas da primeira thread que solicitou...
                //Para as demais threads, faz com que elas aguardem pela renovacao do token.
                if (Interlocked.CompareExchange(ref _refreshTokenEntered, 1, 0) == 0)
                {

                    Console.WriteLine("Refresh Token Renewing...");
                    //tenta renovar
                    var authResponse = await AuthWithRefreshTokenAsync();

                    Interlocked.Exchange(ref _refreshTokenEntered, 0);
                    Console.WriteLine("Refresh Token Renewed");
                    return authResponse.Success;
                }
                else
                {
                    Console.WriteLine("Refresh Token Renewal is Waiting...");

                    while (_refreshTokenEntered == 1)
                    {
                        await Task.Delay(100);
                    }
                    //Faz as outras threads aguardarem até que o token seja renovado no bloco anterior
                    Console.WriteLine("Refresh Token Renewal done!");
                    return true;
                }
            }

            catch (Exception)
            {
                Interlocked.Exchange(ref _refreshTokenEntered, 0);
                throw;
            }

        }

        private async Task<AuthResponse> AuthWithRefreshTokenAsync()
        {
            string token = Preferences.Get("BearerToken", string.Empty);
            httpClient.DefaultRequestHeaders.Add("x-access-tokens", token);
            dynamic jsonObject = new JObject();
            jsonObject.RefreshToken = Preferences.Get("BearerToken", string.Empty);

          //  httpClient.DefaultRequestHeaders.Add("Accept", token);
          //  httpClient.DefaultRequestHeaders.Add("Content-Type", token);
            // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.GetAsync(REFRESH_TOKEN_URL);

            if (responseMessage.IsSuccessStatusCode)
            {
                var stringResponse = await responseMessage.Content.ReadAsStringAsync();
                var authResponse = JsonConvert.DeserializeObject<AuthResponse>(stringResponse);

                Preferences.Set("BearerToken", authResponse.access_token);
                Preferences.Set("RefreshToken", authResponse.RefreshToken);

                return authResponse;
            }
            else
            {
                return new AuthResponse();
            }

        }

    }

}
