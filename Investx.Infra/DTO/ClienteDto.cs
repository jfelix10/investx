using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Investx.Infra.Entidades
{
    public class ClienteDto
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string ativo { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public int tipo { get; set; }

    }
}
