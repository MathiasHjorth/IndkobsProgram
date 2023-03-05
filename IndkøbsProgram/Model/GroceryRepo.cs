using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IndkøbsProgram.Model
{
    public class GroceryRepo
    {
        private string connectionPath = "Indkøb.txt";
        private const int ATTRIBUTES_FOR_GROCERY = 5;
        public int MaxId { get => GetMaxIdValue(); }

        private List<Grocery> groceryList;
        private List<string> stringList;
        public GroceryRepo()
        {
            groceryList = new List<Grocery>();
            stringList = new List<string>();
            InitializeList();
        }

        private void InitializeList()
        {
            using (StreamReader sr = new StreamReader(connectionPath))
            {
                while (sr.EndOfStream == false)
                {
                    stringList.Add(sr.ReadLine());
                    if (stringList.Last() == "")
                    {
                        stringList.Remove(stringList.Last());
                    }
                }
                //lav stringlist om til Grocery modeller og tilføj til indkapslede liste
                for (int i = 0; i < stringList.Count(); i++)
                {
                    string[] splitArray = new string[ATTRIBUTES_FOR_GROCERY];
                    splitArray = stringList[i].Split('/');
                    try
                    {
                        GroceryShop gs = new GroceryShop(splitArray[2], splitArray[3]);
                        groceryList.Add(new Grocery(Convert.ToDouble(splitArray[0]), Convert.ToDateTime(splitArray[1]), gs, Convert.ToInt32(splitArray[4])));
                    }
                    catch
                    {
                    }                  
                }
            }
            //Arrange list
            groceryList = groceryList.OrderByDescending(g => g.ShoppingDate.Date).ToList();
        }

        public void AddToTextFile(Grocery grocery)
        {
            string line = "";
            foreach(string s in stringList)
            {
                line += s + "\n";
            }
            //Ændre grocery id til maxID + 1 (inkrementering for id)
            grocery.Id = GetMaxIdValue();
            stringList.Add(grocery.ToString());
            groceryList.Add(grocery);
            using (StreamWriter sw = new StreamWriter(connectionPath))
            {
                sw.WriteLine(line + grocery.ToString());
            }
        }
        public void DeleteGrocery(int id)
        {
            //Fjern grocery fra listen
            foreach(Grocery g in groceryList)
            {
                if(g.Id == id)
                {
                    groceryList.Remove(g);
                    break;
                }
            }
            //Fjern string objektet fra string listen
            for (int i = 0; i < stringList.Count(); i++)
            {
                string[] splitArray = new string[ATTRIBUTES_FOR_GROCERY];
                splitArray = stringList[i].Split('/');
                try
                {
                    if (splitArray[4] == id.ToString())
                    {
                        stringList.Remove(stringList[i]);
                        break;
                    }
                }
                catch
                {
                }
            }
            //Opdater tekstfilen
            UpdateTextFile();
        }

        public List<Grocery> GetList()
        {
            return groceryList;
        }

        public void UpdateTextFile()
        {
            //Tøm string listen ind i tekstfilen
            string line = "";
            foreach (string s in stringList)
            {
                line += s + "\n";
            }
            using (StreamWriter sw = new StreamWriter(connectionPath))
            {
                sw.WriteLine(line);
            }
        }

        private int GetMaxIdValue()
        {
            if(groceryList.Count != 0)
            {
                int currentMax = 0;
                foreach(Grocery g in groceryList)
                {
                    currentMax = g.Id;
                    if(currentMax < g.Id)
                    {
                        currentMax = g.Id;
                    }
                }
                return currentMax+1;
            }
            else
            {
                return 0+1;
            }
        }
    }
}
