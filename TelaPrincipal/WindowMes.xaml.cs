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

namespace TelaPrincipal
{
    /// <summary>
    /// Interaction logic for WindowMes.xaml
    /// </summary>
    public partial class WindowMes : Window
    {
        Compromissos listaCompromissos;
        public WindowMes()
        {
            InitializeComponent();
            listaCompromissos = new Compromissos();
            retornaMes();
        }
        public void retornaMes()
        {
            abrirArquivo<Compromissos>(ref compromis, "c:\\temp\\compromissos.xml");
            lbCompromissos.ItemsSource = null;
            lbCompromissos.ItemsSource = compromis;
           // dgVisualizaMes.ItemsSource = null;
           // dgVisualizaMes.ItemsSource = listaCompromissos;
        }
    }
}
