using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFarfetch.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; }
        

        public Categories categories { get; set; }



    }
    public enum Categories
    {
        Drink,
        Clothing,
        Food
    }
}