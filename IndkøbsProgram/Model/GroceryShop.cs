using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndkøbsProgram.Model
{
    public class GroceryShop
    {

        public string ShopName { get; set; }
        public string ShopColor { get; set; }

        private List<GroceryShop> shopsList;

        public GroceryShop()
        {
            shopsList = new List<GroceryShop>();
            InitializeList();
        }
        public GroceryShop(string name, string shopColor)
        {
            ShopName = name;
            ShopColor = shopColor;
        }

        private void InitializeList()
        {
            shopsList.Add(new GroceryShop("Rema 1000", "#FF0F2A87"));
            shopsList.Add(new GroceryShop("Netto", "#777777"));
            shopsList.Add(new GroceryShop("Coop 365", "#47B422"));
            shopsList.Add(new GroceryShop("Aldi", "#45B1FF"));
            shopsList.Add(new GroceryShop("Lidl", "#F8E017"));
            shopsList.Add(new GroceryShop("Fakta", "#D21818"));
            shopsList = shopsList.OrderBy(x => x.ShopName).ToList();
        }

        public List<GroceryShop> GetList()
        {
            return shopsList;
        }
    }
}
