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
using System.Globalization;




namespace TelaPrincipal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Compromissos Lcomp;
        private int mesSelecionado;
        private string[] meses; 
        public MainWindow()
        {
            InitializeComponent();
            AbrirArquivo();
            mesSelecionado = 3;
            meses = new string[] {"Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"};
            visualizarMes();
            
            
         //   AddSelectedDates();  
           
          // setDisplayDates(); 
        }

       


        public void AbrirArquivo()
        {
            try
            {
                // Tenta recuperar o objeto r da classe T do
                // arquivo "arquivo"
                Persistencia<Compromissos> arq = new Persistencia<Compromissos>();
                Lcomp = arq.AbrirArquivo("c:\\temp\\compromissos.xml");
            }
            catch
            {
                // Se não existia o arquivo, um novo objeto
                // da classe T é instanciado
                Lcomp = new Compromissos();
            }

            Listar();
        }



        public void Listar()
        {
            var listaDataGridFormat = Lcomp.Select(v => new { v.Nome, v.Data, v.Urgente}).OrderBy(v => v.Data);
            DataGrid1.ItemsSource = listaDataGridFormat;           
        }
 
       

        private void AbrirJanelaAdicionar(object sender, RoutedEventArgs e)
        {
            JanelaAdicionar j = new JanelaAdicionar();
            j.Referenciar(this.Lcomp);
            j.ShowDialog();

            if(j.DialogResult ==  true)
            {
                Listar();
            }
        }

   
        // abaixo, manipulação de calendário
        /*
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
        acima, manipulação de calendário*/

        public void visualizarMes()
        {
          
            var listaMes = Lcomp.Select(v => new { v.Nome, v.Data., v.HInicial, v.HFinal, v.Urgente }).Where(v => v.Data.Month == this.mesSelecionado).OrderBy(v => v.Data);
            dgListaMes.ItemsSource = listaMes;
            txtMeses.Text = meses[this.mesSelecionado -1]; 
        }

        private void listarProximoMes(object sender, RoutedEventArgs e)
        {
            mesSelecionado++;
            visualizarMes();
        }

        private void listarAnteriorMes(object sender, RoutedEventArgs e)
        {
            mesSelecionado--;
            visualizarMes();
        }

  
        

  


    }
}
// http://www.codeproject.com/Articles/30329/Creating-an-Outlook-Calendar-using-WPF-Part
// http://www.c-sharpcorner.com/uploadfile/mahesh/wpf-calendar-control/
// http://www.jarloo.com/wpf-calendar-control/
// http://www.tomasvasquez.com.br/blog/desenvolvimento/c-formatos-customizados-para-o-datetime