using Investx.Domain.Entidades;
using Investx.Infra;
using Investx.Infra.Entidades;
using System;
using System.Collections.Generic;

namespace Investx.Domain
{
    public class ClienteXDomain
    {
        public void DeleteCliente(string cpf) {
            var clienteInvesXRepository = new ClienteXRepository();
            clienteInvesXRepository.Delete(cpf);
        }
        public void Inserir(Cliente cliente) {
            
            var clienteDto = new ClienteDto();
            clienteDto.tipo = cliente.Tipo;
            clienteDto.nome = cliente.Nome;
            clienteDto.ativo = cliente.Ativo;
            clienteDto.nome = cliente.Nome;
            clienteDto.cpf = cliente.Cpf;
            clienteDto.email = cliente.Email;
            clienteDto.senha = cliente.Senha;
            clienteDto.rg = cliente.Rg;

            var classeInvesXRepository = new ClienteXRepository();
            classeInvesXRepository.Inserir(clienteDto);
        }
        public void Atualizar(Cliente cliente, string cpf)
        {
            var clienteDto = new ClienteDto();
            clienteDto.tipo = cliente.Tipo;
            clienteDto.nome = cliente.Nome;
            clienteDto.ativo = cliente.Ativo;
            clienteDto.nome = cliente.Nome;
            clienteDto.cpf = cliente.Cpf;
            clienteDto.email = cliente.Email;
            clienteDto.senha = cliente.Senha;
            clienteDto.rg = cliente.Rg;

            var classeInvesXRepository = new ClienteXRepository();
            classeInvesXRepository.Atualizar(clienteDto, cpf);
        }
        public List<Cliente> RecuperarClientes()
        {
            var classeInvesXRepository = new ClienteXRepository();
            var lista = classeInvesXRepository.RecuperarClientes();

            List<Cliente> clientes = new List<Cliente>();

            foreach (ClienteDto cliente in lista)
            {
                clientes.Add
                (
                    new Cliente
                    {
                        Ativo = cliente.ativo,
                        Cpf = cliente.cpf,
                        Email = cliente.email,
                        Nome = cliente.nome,
                        Rg = cliente.rg,
                        Senha = cliente.senha,
                        Tipo = cliente.tipo
                    }
                );
            }

            return clientes;
        }
        public Cliente RecuperarCliente(string cpf)
        {
            var classeInvesXRepository = new ClienteXRepository();
            var clienteDto = classeInvesXRepository.RecuperarCliente(cpf);

            var cliente = new Cliente
            {
                Ativo = clienteDto.ativo,
                Cpf = clienteDto.cpf,
                Email = clienteDto.email,
                Nome = clienteDto.nome,
                Rg = clienteDto.rg,
                Senha = clienteDto.senha,
                Tipo = clienteDto.tipo
            };

            return cliente;
        }
    }
}
