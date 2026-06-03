using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia
{
    public class Servico
    {
        public int ID_Servico { get; set; }
        public string Nome_Servico { get; set; }
        public decimal Preco_base { get; set; }
        public int? Unidades { get; set; } // O '?' permite aceitar valores nulos (null) do SQL

        // Define o que vai aparecer escrito na ListBox
        public override string ToString()
        {
            return $"{Nome_Servico} - {Preco_base.ToString("C2", new System.Globalization.CultureInfo("pt-PT"))}";
        }
    }
}
