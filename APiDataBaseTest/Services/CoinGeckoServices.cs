using APiDataBaseTest.DBContext;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace APiDataBaseTest
{

    public class CoinGeckoServices : ICoinGeckoServices
    {
        private readonly MyContext myContext;
        private readonly RestClient myRestClient; 

        public CoinGeckoServices(MyContext myContext, RestClient myRestClient)
        {
            this.myContext = myContext;
            this.myRestClient = myRestClient;
        }

        public List<Crypto> GetCryptoList()
        {
            var request = new RestRequest("api/v3/coins/list", Method.Get);
            var q = myRestClient.Get(request);
            var cryptoList = JsonSerializer.Deserialize<List<Crypto>>(q.Content);
            return cryptoList.ToList();
        }

        public int GetCount()
        {
            return myContext.Cryptos.Count();
        }
        public int GetCoinCount()
        {
            double coinCount = (myContext.Cryptos.Count()) / 250.0;
            return ((int)Math.Ceiling(coinCount));
        }

        public List<CryptoInfo> GetCryptoInfo()
        {
            List<CryptoInfo> cryptoInfoList = new List<CryptoInfo>();
            for (int i = 1; i <= GetCoinCount(); i++)
            {
                var request = new RestRequest($"api/v3/coins/markets?vs_currency=usd&order=id_asc&per_page=250&page={i}", Method.Get);
                var q = myRestClient.Get(request);
                var JsonCryptosInfo = JsonSerializer.Deserialize<JsonNode>(q.Content);


                List<CryptoInfo> cryptoInfos = new List<CryptoInfo>();
                Console.WriteLine(JsonCryptosInfo.AsArray().Count());
                foreach (var item in JsonCryptosInfo.AsArray())
                {
                    if(myContext.Cryptos.Any(c=>c.id == item["id"].ToString()))
                    {
                        CryptoInfo cryptoInfo = new CryptoInfo();
                        cryptoInfo.CryptoId = item["id"].ToString();
                        cryptoInfo.current_price = (((double?)item["current_price"]));
                        cryptoInfo.last_updated = item["last_updated"]?.ToString();
                        cryptoInfo.market_cap = (((double?)item["market_cap"]));
                        cryptoInfo.total_volume = (((double?)item["total_volume"]));
                        cryptoInfoList.Add(cryptoInfo);
                    }

                }
                Thread.Sleep(20000);
            }

            return cryptoInfoList;

        }

        public List<Category> GetCategories()
        {
            var request = new RestRequest("api/v3/coins/categories", Method.Get);
            var q = myRestClient.Get(request);
            var category = JsonSerializer.Deserialize<List<Category>>(q.Content);
            return category.ToList();
        }



        public List<OHLC> GetOHLCs()
        {
            List<OHLC> ohlcList = new List<OHLC>();
            var request = new RestRequest("api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=30&page=1", Method.Get);
            var q = myRestClient.Get(request);
            var JsonCryptosInfo = JsonSerializer.Deserialize<JsonNode>(q.Content);

            foreach (var item in JsonCryptosInfo.AsArray())
            {
                var requestt = new RestRequest($"api/v3/coins/{item["id"]}/ohlc?vs_currency=usd&days=365", Method.Get);
                var qq = myRestClient.Get(requestt);
                var ohcl = JsonSerializer.Deserialize<JsonNode>(qq.Content);
                Console.WriteLine(ohcl.AsArray().Count());

                foreach (var item2 in ohcl.AsArray())
                {
                    OHLC oHCL = new OHLC();
                    oHCL.CryptoId = item["id"].ToString();
                    oHCL.dateTime = ((long)item2[0]).GetDate();
                    oHCL.O = ((double?)item2[1]);
                    oHCL.H = ((double?)item2[2]);
                    oHCL.C = ((double?)item2[3]);
                    oHCL.L = ((double?)item2[4]);

                    ohlcList.Add(oHCL);
                }
                Thread.Sleep(5000);
            }

            return ohlcList;
        }



        public void AddCategory()
        {
            myContext.Categories.AddRange(GetCategories());
            myContext.SaveChanges();
        }

        public void AddCoinInformation()
        {
            myContext.CryptoInfos.AddRange(GetCryptoInfo());
            myContext.SaveChanges();
        }

        public void AddCoinList()
        {
            myContext.Cryptos.AddRange(GetCryptoList());
            myContext.SaveChanges();
        }

        public void AddOHLC()
        {
            myContext.OHLCs.AddRange(GetOHLCs());
            myContext.SaveChanges();
        }

        public void UpdateCryptoInfoTable()
        {
            
                for (int i = 1; i <= GetCoinCount(); i++)
                {
                    var request = new RestRequest($"api/v3/coins/markets?vs_currency=usd&order=id_asc&per_page=250&page={i}", Method.Get);
                    var requestt = myRestClient.Get(request);
                    var JsonCryptosInfo = JsonSerializer.Deserialize<JsonNode>(requestt.Content);


                    List<CryptoInfo> cryptoInfos = new List<CryptoInfo>();
                    Console.WriteLine(JsonCryptosInfo.AsArray().Count());
                    foreach (var item in JsonCryptosInfo.AsArray())
                    {
                        var crypto = myContext.CryptoInfos.FirstOrDefault(c => c.CryptoId == item["id"].ToString());

                        if (crypto != null)
                        {
                            crypto.current_price = (((double?)item["current_price"]));
                            crypto.last_updated = item["last_updated"]?.ToString();
                            crypto.market_cap = (((double?)item["market_cap"]));
                            crypto.total_volume = (((double?)item["total_volume"]));

                            myContext.SaveChanges();
                        }


                    }
                    Thread.Sleep(20000);
                }
            
        }

    }
}
