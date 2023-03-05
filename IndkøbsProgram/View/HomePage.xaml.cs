using IndkøbsProgram.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IndkøbsProgram.View
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            DataContext = MainWindow.mwvm;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mwvm.AddGrocery(new GroceryViewModel(double.Parse(PriceTxtBox.Text),DatePickerBox.SelectedDate ?? DateTime.Now, new GroceryShopViewModel((GroceryShopComboBox.SelectedItem as GroceryShopViewModel).Name,(GroceryShopComboBox.SelectedItem as GroceryShopViewModel).ShopColor)));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.mwvm.SelectedGrocery != null)
                MainWindow.mwvm.DeleteGrocery(MainWindow.mwvm.SelectedGrocery);
        }

        private void HistoryListBox_GotFocus(object sender, RoutedEventArgs e)
        {
            DeleteBtn.IsEnabled = true;
        }
    }
}
