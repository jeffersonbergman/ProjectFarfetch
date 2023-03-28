using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFarfetch.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public double price { get; set; }
        public int stock { get; set; }
        public double tax = 0.06;
        public Category categorys {get; set;}
        
        public decimal FinalPrice
        {
            get 
            { 
                decimal finalPrice = (decimal)(price * stock + (price * tax));
                return Math.Round(finalPrice, 2);
            }
        }
    }

    public enum Category
    {
        Drink,
        Food,
        Clothing
    }
}