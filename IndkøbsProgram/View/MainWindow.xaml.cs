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
using IndkøbsProgram;
using IndkøbsProgram.View;
using IndkøbsProgram.ViewModel;

namespace IndkøbsProgram.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindowViewModel mwvm = new MainWindowViewModel();
        private HomePage hP = new HomePage();
        private StatisticsPage sP = new StatisticsPage();
        public MainWindow()
        {
            InitializeComponent();
            MainContainer.Content = hP;
        }

        #region CosmeticEvents
        //private void PriceTxtBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    mwvm.SelectedGrocery = null;
        //    DeleteBtn.IsEnabled = false;
        //}

        //private void DateTxtBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    mwvm.SelectedGrocery = null;
        //    DeleteBtn.IsEnabled = false;
        //}

        //private void HistoryListBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    DeleteBtn.IsEnabled = true;
        //}

        //private void GroceryShopComboBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    mwvm.SelectedGrocery = null;
        //    DeleteBtn.IsEnabled = false;
        //}

        #endregion
        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContainer.Content = hP;
        }

        private void StatisticsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContainer.Content = sP;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Forside.Close();
        }
    }
}
