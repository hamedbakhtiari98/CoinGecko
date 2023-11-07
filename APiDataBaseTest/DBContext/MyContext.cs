using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APiDataBaseTest.DBContext
{
    public class MyContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-G7IA4K7; Initial Catalog=CryptoDB; Integrated Security=True; TrustServerCertificate=True");
        }


        #region Tables

        public DbSet<Crypto> Cryptos { get; set; }

        public DbSet<CryptoInfo> CryptoInfos { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<OHLC> OHLCs { get; set; }

        #endregion



    }
}
