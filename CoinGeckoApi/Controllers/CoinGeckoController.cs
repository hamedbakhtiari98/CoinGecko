using CoinGecko.API;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Newtonsoft.Json;


namespace CoinGeckoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoinGeckoController : ControllerBase
    {
        CoinGeckoContext coinGeckoContext = new CoinGeckoContext();

        [HttpGet]
        public string GetAllCoin()
        {
            var coinList = coinGeckoContext.Cryptos.Select(e => new {e.id,e.name,e.symbol })
                .ToList();
            return JsonConvert.SerializeObject(coinList, Formatting.Indented);
        }

        [HttpGet]
        [Route("GetInformation")]
        public string GetInformation()
        {
            var coinInformation = coinGeckoContext.CryptoInfos.ToList();
            return JsonConvert.SerializeObject(coinInformation, Formatting.Indented);
        }

        [HttpGet]
        [Route("GetCategory")]
        public string GetCategory()
        {
            var coinInformation = coinGeckoContext.Categories.ToList();
            return JsonConvert.SerializeObject(coinInformation, Formatting.Indented);
        }


        [HttpGet]
        [Route("GetOHLC/{id}/{date}")]
        public string GetOHLC(string id, string date)
        {
            var ohlcInformation = coinGeckoContext.OHCLs.Where(o=>o.CryptoId == id && o.dateTime == date).SingleOrDefault();
            return JsonConvert.SerializeObject(ohlcInformation, Formatting.Indented);
        }
    }
}
