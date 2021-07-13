using Investx.Infra;
using System;
using System.Collections.Generic;

namespace Investx.Domain
{
    public class ClienteXDomain
    {
        public void DeleteCliente(int id) {
            var clienteInvesXRepository = new ClienteXRepository();
            clienteInvesXRepository.Delete(id);
        }
        public void Inserir(Cliente cliente) {
            var classeInvesXRepository = new ClienteXRepository();
            classeInvesXRepository.Inserir(cliente);
        }
        public void Atualizar(Cliente investestidor, int id) {
            var classeInvesXRepository = new ClienteXRepository();
            classeInvesXRepository.Atualizar(investestidor, id);
        }
        public List<Cliente> RecuperarClientes() {
            var classeInvesXRepository = new ClienteXRepository();
            var lista = classeInvesXRepository.RecuperarClientes();
            return lista;
        }
        public Cliente RecuperarCliente(string cpf)
        {
            var classeInvesXRepository = new ClienteXRepository();
            var cliente = classeInvesXRepository.RecuperarCliente(cpf);
            return cliente;
        }
        
    
    }
}
