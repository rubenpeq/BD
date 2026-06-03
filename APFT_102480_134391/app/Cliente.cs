using System;

namespace Barbearia
{
    public class Cliente
    {
        public int ID_Cliente { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string NIF { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }

        public override string ToString()
        {
            return ID_Cliente + " - " + Nome + " " + Apelido;
        }
    }
}