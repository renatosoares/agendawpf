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
using System.IO;
using System.Xml.Serialization;


namespace TelaPrincipal
{
    /// <summary>
    /// Interaction logic for JanelaAdicionar.xaml
    /// </summary>
    public partial class JanelaAdicionar : Window
    {
        public Compromissos LcompAdd;
        public JanelaAdicionar()
        {
            InitializeComponent();
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Referenciar(Compromissos cs)
        {
            this.LcompAdd = cs;
        }

        private void Adicionar(object sender, RoutedEventArgs e)
        {
            Compromisso c = new Compromisso();
            c.Nome = TB1A.Text;
            c.Data = DateTime.Parse(DatePicker.Text);
            c.Urgente = (bool)CheckBox1.IsChecked;
            c.HInicial = TB2AHInicial.Text;
            c.HFinal = TB3AHFinal.Text;
            
            
            

            LcompAdd.Add(c);
            SalvarArquivo();
            Clear();
            MessageBox.Show ("O compromisso foi adicionado com sucesso!");
            
            DialogResult = true;
            this.Close();
               
        }

 

        public void SalvarArquivo ()
        {  
            Persistencia<Compromissos> arq =
            new Persistencia<Compromissos>();
            arq.SalvarArquivo("c:\\temp\\compromissos.xml", LcompAdd);
        }

        public void Clear()
        {
            TB1A.Text = "";
            TB2AHInicial.Text = "";
            TB3AHFinal.Text = "";
            CheckBox1.IsChecked = false;
            DatePicker.ClearValue(DatePicker.SelectedDateProperty);
        }
 
    }
}
