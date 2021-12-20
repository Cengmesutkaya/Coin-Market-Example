using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coin_Market_Example.Models
{
    public class CoinModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public double Price { get; set; }
    }
}