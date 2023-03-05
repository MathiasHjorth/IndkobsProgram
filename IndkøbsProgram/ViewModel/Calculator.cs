using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndkøbsProgram.ViewModel
{
    public class Calculator
    {
        public double CalculateTotal(ObservableCollection<GroceryViewModel> list)
        {
            double total = 0;
            foreach(GroceryViewModel g in list)
            {
                total += g.Price;
            }
            return total;
        }
        public double CalculateTotalForWeek(ObservableCollection<GroceryViewModel> list)
        {
            double totalForWeek = 0;
            List<GroceryViewModel> listOfAllGroceriesWithinCurrentWeek = new List<GroceryViewModel>();

            //Opsætning af GetWeekOfYear metodekald
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            CultureInfo myCI = CultureInfo.CurrentCulture;
            Calendar myCal = myCI.Calendar;
            //Nuværende ugenummer
            int currentWeekNumber = myCal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            //Tilføj de GroceryViewModels som matcher nuværende ugenummer
            foreach(GroceryViewModel g in list)
            {
                int weekNumberForGrocery = myCal.GetWeekOfYear(g.Date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                if(weekNumberForGrocery == currentWeekNumber)
                {
                    listOfAllGroceriesWithinCurrentWeek.Add(g);
                }
            }
            //Summér alle GroceryViewModels price i nuværende uge
            foreach (GroceryViewModel g in listOfAllGroceriesWithinCurrentWeek)
            {
                totalForWeek += g.Price;
            }
            return totalForWeek;
        }
        public double CalculateTotalForMonth(ObservableCollection<GroceryViewModel> list)
        {
            double totalForMonth = 0;
            //Current month
            DateTime currentDate = DateTime.Now;

            foreach (GroceryViewModel g in list)
            {
                if(g.Date.Month == currentDate.Month)
                {
                    totalForMonth += g.Price;
                }
            }

            return totalForMonth;
        }

    }
}
