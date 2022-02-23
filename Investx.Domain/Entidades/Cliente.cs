using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Investx.Domain.Entidades
{    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Ativo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Tipo { get; set; }
    }
}
