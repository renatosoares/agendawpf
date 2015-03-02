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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Compromisso c = new Compromisso();
            c.Nome = TB1A.Text;
            c.Data = DateTime.Parse(DatePicker.Text);
            c.Urgente = (bool)CheckBox1.IsChecked;
            c.HInicial = TB2AHInicial.Text;
            c.HFinal = TB3AHFinal.Text;


            
            

          //  if (c.HFinal > TB2AHInicial.Text) { 

            


            


        }



    }
}
