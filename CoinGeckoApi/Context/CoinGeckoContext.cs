﻿using Microsoft.EntityFrameworkCore;

namespace CoinGecko.API
{
    public class CoinGeckoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-G7IA4K7; Initial Catalog=CryptoDB; Integrated Security=True; TrustServerCertificate=True");
        }


        #region Tables

        public DbSet<Crypto> Cryptos { get; set; }

        public DbSet<CryptoInfo> CryptoInfos { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<OHCL> OHCLs { get; set; }

        #endregion


    }
}
