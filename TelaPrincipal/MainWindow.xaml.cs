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

namespace TelaPrincipal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Compromissos Lcomp;
        public MainWindow()
        {
            InitializeComponent();
            Lcomp = new Compromissos();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JanelaAdicionar j = new JanelaAdicionar();
            j.Referenciar(this.Lcomp);
            j.ShowDialog();
            

        }

        private void Listar(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataGrid1.ItemsSource = null;
            Compromisso c = new Compromisso();
            c.Nome = "Renato";
            c.Urgente = true;
            c.HFinal ="14h";
            c.HInicial = "11h";
            c.Data = DateTime.Parse("11/11/1990");
            Compromissos l = new Compromissos();



            l.Add(c);
            DataGrid1.ItemsSource = l;
          //  DataGrid1.ItemTemplate.
        }


    }
}
