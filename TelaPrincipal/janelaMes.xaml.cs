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
using System.Windows.Shapes;
using System.Globalization;
using Jarloo.Calendar;

namespace TelaPrincipal
{
    /// <summary>
    /// Interaction logic for janelaMes.xaml
    /// </summary>
    public partial class janelaMes : Window
    {
        public janelaMes()
        {
            InitializeComponent();

            List<string> months = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            cboMonth.ItemsSource = months;

            for (int i = -50; i < 50; i++)
            {
                cboYear.Items.Add(DateTime.Today.AddYears(i).Year);
            }

            cboMonth.SelectedItem = months.FirstOrDefault(w => w == DateTime.Today.ToString("MMMM"));
            cboYear.SelectedItem = DateTime.Today.Year;

            cboMonth.SelectionChanged += (o, e) => RefreshCalendar();
            cboYear.SelectionChanged += (o, e) => RefreshCalendar();
        }

        private void RefreshCalendar()
        {
            if (cboYear.SelectedItem == null) return;
            if (cboMonth.SelectedItem == null) return;

            int year = (int)cboYear.SelectedItem;

            int month = cboMonth.SelectedIndex + 1;

            DateTime targetDate = new DateTime(year, month, 1);

            Calendar.BuildCalendar(targetDate);
        }

        private void Calendar_DayChanged(object sender, DayChangedEventArgs e)
        {
            //save the text edits to persistant storage
        }
        
        // abaixo a manipulação de datas
        private void setDisplayDates()
        {
            
            MonthlyCalendar.DisplayDateStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            MonthlyCalendar.DisplayDateEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }
        private void SetBlackOutDates()
        {

            MonthlyCalendar.BlackoutDates.Add(new CalendarDateRange(
                new DateTime(2015, 3, 1)

                ));
            MonthlyCalendar.BlackoutDates.Add(new CalendarDateRange(
                new DateTime(2015, 3, 8)
                ));

        }
        private void AddSelectedDates()
        {
           
            MonthlyCalendar.SelectedDates.Add(new DateTime(2015, 3, 5));
            MonthlyCalendar.SelectedDates.Add(new DateTime(2015, 3, 15));
            MonthlyCalendar.SelectedDates.Add(new DateTime(2015, 3, 25));
        }  

      

    }
}
