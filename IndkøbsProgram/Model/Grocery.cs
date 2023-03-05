using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndkøbsProgram.Model
{
    public class Grocery
    {
        public double Price { get; set; }
        public DateTime ShoppingDate { get; set; }
        public int Id { get; set; }
        public GroceryShop Shop { get; set; }

        public Grocery(double price, DateTime shoppingDate, GroceryShop groceryshop, int id)
        {
            Price = price;
            ShoppingDate = shoppingDate;
            Shop = groceryshop;
            Id = id;
        }

        public override string ToString()
        {
            return $"{Price}/{ShoppingDate}/{Shop.ShopName}/{Shop.ShopColor}/{Id}";
        }
    }
}
