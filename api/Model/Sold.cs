using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Sold
    {
        public int SoldId { get; set; }
        public int ClientId { get; set; }
        public int SellerId { get; set; }
        public string Price { get; set; }
        public int amount { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public Seller Seller { get; set; }
    }
}
