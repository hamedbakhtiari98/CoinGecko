using RestSharp;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APiDataBaseTest.DBContext;
using System.Net;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using Quartz;
using Quartz.Impl;
using APiDataBaseTest;



var client = new RestClient("https://api.coingecko.com");
MyContext MyContext = new MyContext();

ICoinGeckoServices coinGeckoService = new CoinGeckoServices(MyContext, client);
//UpdateJob job = new UpdateJob(MyContext, client);


//coinGeckoService.AddCoinList();
//coinGeckoService.AddCategory();
//Console.WriteLine(coinGeckoService.GetCount().ToString()); ;
//coinGeckoService.AddCoinInformation();
//coinGeckoService.AddOHLC();
//await job.UpdateJobAsync();