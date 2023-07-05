using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectFarfetch.Entities;

namespace ProjectFarfetch.Categorie
{
    public class Clothing : Product
    {
        public string Size { get; set; }

        public double Tax = 0.07;
        public string Description { get; set; }

         public double FinalPrice 
        { 
            get
            {
                double finalPrice = (double)(Price * Quantity + (Price * Tax));
                return Math.Round(finalPrice, 2);
            }
        }
    }
}