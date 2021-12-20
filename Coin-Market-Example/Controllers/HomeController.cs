using Coin_Market_Example.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coin_Market_Example.Controllers
{
    public class HomeController : Controller
    {
        private static string API_KEY = "d785d853-d216-48bd-9f9a-c15491918b4d";
        List<CoinModel> coinModelLst = new List<CoinModel>();
        public ActionResult Index()
        {
            string URL = ("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";

            var client = new System.Net.WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");

            var json = client.DownloadString(URL);
            dynamic parsed = JsonConvert.DeserializeObject(json);
            if (parsed.status.error_message == null)
            {
                JsonToList(parsed.data);
            }
            else
            {
                throw new Exception(parsed.status.error_message);
            }
             return View(coinModelLst);                  
        }

        private void JsonToList(dynamic data)
        {
            foreach (var result in data)
            {
                CoinModel coinModel = new CoinModel();
                coinModel.Id = result.id;
                coinModel.Name = result.name;
                coinModel.Symbol = result.symbol;
                coinModel.AddedDate = result.date_added;
                coinModel.UpdateDate = result.last_updated;
                coinModel.Price = result.quote.USD.price;               
                coinModelLst.Add(coinModel);
            }
        }
    }
}