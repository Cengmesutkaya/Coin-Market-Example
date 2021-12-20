﻿using Newtonsoft.Json;
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

        public ActionResult Index()
        {
            makeAPICall(); 
            return View();
        }
        public string makeAPICall()
        {
            string URL = ("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";

            //URL.Query = queryString.ToString();

            var client = new System.Net.WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            dynamic test = client.DownloadString(URL.ToString());

            var json = client.DownloadString(URL);
            dynamic parsed = JsonConvert.DeserializeObject(json);
            JsonToList(parsed);
            return test;

        }

        private void JsonToList(dynamic obj)
        {
            foreach (var result in obj)
            {
                foreach (var item in result)
                {
                    //ExchangeRateModel rateType = new ExchangeRateModel();
                    //rateType.RateTypeName = result.Name;
                    //rateType.Names = item.isim;
                    //rateType.Buying = item.alis;
                    //rateType.Selling = item.satis;
                    //rateType.Changing = (Convert.ToDecimal(item.degisim) / 100);
                    //rateTypeList.Add(rateType);
                }
            }
        }
    }
}