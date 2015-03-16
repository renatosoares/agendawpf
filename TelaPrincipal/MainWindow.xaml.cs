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
            AbrirArquivo();
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


    }
}
