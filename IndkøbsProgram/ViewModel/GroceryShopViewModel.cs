using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndkøbsProgram.ViewModel
{
    public class GroceryShopViewModel
    {
        public string Name { get; set; }
        public string ShopColor { get; set; }

        public GroceryShopViewModel(string name, string shopColor)
        {
            Name = name;
            ShopColor = shopColor;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
