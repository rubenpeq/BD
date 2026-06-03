using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Barbearia
{
    public class Barbeiro
    {
        public int ID_Barbeiro { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string NIF { get; set; }
        public string Telefone { get; set; }
        public string Especialidade { get; set; }

        
        public override string ToString()
        {
            return ID_Barbeiro + " - " + Nome + " " + Apelido;
        }
    }
}