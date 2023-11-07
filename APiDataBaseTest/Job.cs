using Quartz;
using APiDataBaseTest.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Nodes;
using Quartz;
using Quartz.Impl;

namespace APiDataBaseTest
{
    public class UpdateJob : IJob
    {

        MyContext MyContext = new MyContext();
        RestClient client = new RestClient("https://api.coingecko.com");

        public Task Execute(IJobExecutionContext context)
        {
            double iterate = Math.Ceiling((MyContext.Cryptos.Count() / 250.0));
            for (int i = 1; i <= iterate; i++)
            {
                var request = new RestRequest($"api/v3/coins/markets?vs_currency=usd&order=id_asc&per_page=250&page={i}", Method.Get);
                var requestt = client.Get(request);
                var JsonCryptosInfo = JsonSerializer.Deserialize<JsonNode>(requestt.Content);


                List<CryptoInfo> cryptoInfos = new List<CryptoInfo>();
                Console.WriteLine(JsonCryptosInfo.AsArray().Count());
                foreach (var item in JsonCryptosInfo.AsArray())
                {
                    var crypto = MyContext.CryptoInfos.FirstOrDefault(c => c.CryptoId == item["id"].ToString());

                    if (crypto != null)
                    {
                        crypto.current_price = (((double?)item["current_price"]));
                        crypto.last_updated = item["last_updated"]?.ToString();
                        crypto.market_cap = (((double?)item["market_cap"]));
                        crypto.total_volume = (((double?)item["total_volume"]));

                        MyContext.SaveChanges();
                    }


                }
                Thread.Sleep(20000);
            }

            return Task.CompletedTask;
        }
    }
}
