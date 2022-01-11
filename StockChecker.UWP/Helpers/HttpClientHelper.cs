using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StockChecker.UWP.Helpers
{
    public class HttpClientHelper : IHttpStockClientHelper
    {
        static HttpClient _httpClient;
        private static string _accessToken;
        public HttpClientHelper(Uri baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public async Task<bool> Login(string username, string password)
        {
            var disco = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "https://localhost:7137"
            });
            var response = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "StockChecker",
                ClientSecret = "secret",
                Scope = "StockCheckerApi",
                UserName = username,
                Password = password
            });
            if(response.IsError)
            {
                //Log Error
                return false;
            }
            _accessToken = response.AccessToken;
            return true;
        }
        public async Task<int> GetQuantityAsync(int productId)
        {
            string path = $"api/stock/{productId}";
            _httpClient.SetBearerToken(_accessToken);
            string quantityString = await _httpClient.GetStringAsync(path);
            return int.Parse(quantityString);
        }

        

        public async Task UpdateQuantityAsync(int productId, int newQuantity)
        {
            string path = $"api/stock/{productId}";
            _httpClient.SetBearerToken(_accessToken);
            var httpContent = new StringContent(newQuantity.ToString());
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await _httpClient.PutAsync(path, httpContent);
        }
    }
}
