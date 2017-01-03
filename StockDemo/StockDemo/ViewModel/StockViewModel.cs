using StockDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StockDemo.ViewModel
{
    public class StockViewModel
    {
        public QuoteData Data { get; set; } = null;

        public bool IsBusy { get; set; } = false;

        public async Task<bool> GetQuote(string ticker)
        {
            if (IsBusy)
                return false;

            try
            {
                IsBusy = true;
                var url = "https://motzstocks2.azurewebsites.net/api/"
                    + $"HttpTriggerCSharp1?ticker={ticker}";

                var client = new HttpClient();
                var json = await client.GetStringAsync(url);

                Data = JsonConvert.DeserializeObject<QuoteData>(json);
            }
            catch(Exception ex)
            {
                Data = null;
                return false;
            }
            finally
            {
                IsBusy = false;
            }

            return true;

        }
    }
}
