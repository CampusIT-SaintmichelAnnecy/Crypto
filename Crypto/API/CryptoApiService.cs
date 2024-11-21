using Crypto.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crypto.API
{
    public static class CryptoApiService
    {
        private const string ApiUrl = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd";

        public static async Task<List<Root>> GetCryptoCurrenciesAsync()
        {
            HttpClient client = new HttpClient();
            try
            {
                string response = await client.GetStringAsync(ApiUrl);
                return JsonConvert.DeserializeObject<List<Root>>(response);
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
