using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaPrincipal
{
    public class Compromisso
    {
        public string Nome { set; get; }
        public DateTime Data { set; get; }
        public string HInicial { set; get; }
        public string HFinal { set; get; }
        public bool Urgente { set; get; }
       

    }

    public class Compromissos : List<Compromisso>
    { 
    }

}
