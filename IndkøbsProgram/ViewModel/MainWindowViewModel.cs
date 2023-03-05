using IndkøbsProgram.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndkøbsProgram.ViewModel
{
    public delegate void UpdateListDelegate();
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private GroceryRepo gRepo = new GroceryRepo();
        private GroceryShop gShop = new GroceryShop();
        private Calculator calculator = new Calculator();

        private ObservableCollection<GroceryViewModel> groceryList = new ObservableCollection<GroceryViewModel>();

        public ObservableCollection<GroceryViewModel> GroceryList 
        {
            get { return groceryList ; }
            set { groceryList = value; }          
        }

        public ObservableCollection<GroceryShopViewModel> GroceryShopList { get; set; } = new ObservableCollection<GroceryShopViewModel>();
        public string DatePickerWaterMarkValue { get;} = DateTime.Now.ToString("d");
        public GroceryViewModel SelectedGrocery { get; set; }

        public event UpdateListDelegate OnListChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        private double total;

        public double Total
        {
            get { return calculator.CalculateTotal(groceryList); }
            set { total = value; 
                OnPropertyChanged(nameof(total)); 
            }
        }

        private double totalForWeek;

        public double TotalForWeek
        {
            get { return calculator.CalculateTotalForWeek(groceryList); }
            set { totalForWeek = value;
                OnPropertyChanged(nameof(totalForWeek));
            }
        }

        private double totalForMonth;

        public double TotalForMonth
        {
            get { return calculator.CalculateTotalForMonth(groceryList); }
            set
            {
                totalForMonth = value;
                OnPropertyChanged(nameof(totalForMonth));
            }
        }


        public MainWindowViewModel()
        {
            InitializeGroceryList(gRepo.GetList());
            InitializeGroceryShopList(gShop.GetList());
            OnListChanged += ReArrangeByDate;
            OnListChanged += UpdateTotals;
        }

        public void AddGrocery(GroceryViewModel groceryViewModel)
        {
            //Giver den nye groceryViewModel et id i stedet for 0
            groceryViewModel.Id = gRepo.MaxId;
            GroceryList.Add(groceryViewModel);
            gRepo.AddToTextFile(new Grocery(groceryViewModel.Price, Convert.ToDateTime(groceryViewModel.Date), new GroceryShop(groceryViewModel.Shop.Name, groceryViewModel.Shop.ShopColor), groceryViewModel.Id));
            //Affyr event
            OnListChanged();
        }

        public void DeleteGrocery(GroceryViewModel groceryViewModel)
        {
            GroceryList.Remove(groceryViewModel);
            gRepo.DeleteGrocery(groceryViewModel.Id);
            //Affyr event
            OnListChanged();
        }

        private void InitializeGroceryList(List<Grocery> list)
        {
            foreach (Grocery g in list)
            {
                GroceryList.Add(new GroceryViewModel(g.Price, g.ShoppingDate, new GroceryShopViewModel(g.Shop.ShopName, g.Shop.ShopColor), g.Id));
            }
        }

        private void InitializeGroceryShopList(List<GroceryShop> list)
        {
            foreach (GroceryShop g in list)
            {
                GroceryShopList.Add(new GroceryShopViewModel(g.ShopName, g.ShopColor));
            }
        }


        //------------------------------EVENT METHODS-------------------------------\\
        private void ReArrangeByDate()
        {
            List<GroceryViewModel> query = GroceryList.OrderByDescending(g => g.Date.Date).ToList();
            GroceryList.Clear();
            foreach (GroceryViewModel g in query)
            {
                GroceryList.Add(g);
            }
        }
        
        private void UpdateTotals()
        {
            Total = calculator.CalculateTotal(groceryList);
            TotalForWeek = calculator.CalculateTotalForWeek(groceryList);
            TotalForMonth = calculator.CalculateTotalForMonth(groceryList);
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
