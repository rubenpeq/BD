using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia
{
    public class LinhaAgendamento
    {
        public int ID_Servico { get; set; }
        public string Nome_Servico { get; set; }
        public int ID_Barbeiro { get; set; }
        public string Nome_Barbeiro { get; set; }
        public decimal Preco_Praticado { get; set; }
    }
}
