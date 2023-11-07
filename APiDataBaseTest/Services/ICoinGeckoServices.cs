using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APiDataBaseTest
{
    public interface ICoinGeckoServices
    {
        List<Crypto> GetCryptoList();
        List<CryptoInfo> GetCryptoInfo();
        List<Category> GetCategories();
        List<OHLC> GetOHLCs();

        int GetCount();
        void AddCoinList();
        void AddCoinInformation();
        void AddCategory();
        void AddOHLC();

        void UpdateCryptoInfoTable();

    }
}
