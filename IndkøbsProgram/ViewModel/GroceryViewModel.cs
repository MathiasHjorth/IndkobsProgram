using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndkøbsProgram.View;
using IndkøbsProgram.Model;
using System.Globalization;

namespace IndkøbsProgram.ViewModel
{
    public class GroceryViewModel
    {
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public string DateFormatted { get => Date.ToString("M");}
        public GroceryShopViewModel Shop { get; set; }
        public int Id { get; set; }

        public GroceryViewModel()
        {
                
        }
        public GroceryViewModel(double price, DateTime date, GroceryShopViewModel groceryShop, int id)
        {
            Price = price;
            Date = date;
            Shop = groceryShop;
            Id = id;
        }
        public GroceryViewModel(double price, DateTime date, GroceryShopViewModel groceryShop):this(price,date,groceryShop,0)
        {
            Price = price;
            Date = date;
            Shop = groceryShop;
        }
    }
}
