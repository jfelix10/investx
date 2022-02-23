using Dapper;
using Investx.Infra.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Investx.Infra
{
    public class ClienteXRepository
    {
        public void Inserir(ClienteDto cliente)
        {
            
            var enderecoConexao = RetornaStringDeConexao();
            using (var nossaconexao = new SqlConnection(enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("INSERT INTO [cliente] VALUES ('" + cliente.nome + "','" + cliente.cpf + "','" + cliente.rg + "','" + cliente.ativo + "','" + cliente.email + "','" + cliente.senha + "','" + cliente.tipo + "');");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    nossaconexao.Close();
                }

            }


        }

        public List<ClienteDto> RecuperarClientes()
        {
            var enderecoConexao = RetornaStringDeConexao();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    var investidores = nossaconexao.Query<ClienteDto>("SELECT * FROM [INVESTX].[dbo].[Cliente]").AsList();
                    
                    return investidores;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    nossaconexao.Close();
                }
            }
        }

        public ClienteDto RecuperarCliente(string cpf) {
            var enderecoConexao = RetornaStringDeConexao();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    var clientes = nossaconexao.Query<ClienteDto>("SELECT * FROM [INVESTX].[dbo].[Cliente]" + " where cpf= " + cpf).AsList();

                    return clientes[0];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    nossaconexao.Close();
                }
            }
        }

        public void Atualizar(ClienteDto cliente, string cpf)

        {
            var enderecoConexao = RetornaStringDeConexao();

            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("UPDATE [INVESTX].[dbo].[cliente] " + "set nome = '" + cliente.nome + "' where cpf = " + cpf);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    nossaconexao.Close();
                }
            }
        }

        public void Delete(string cpf)
        {
            var enderecoConexao = RetornaStringDeConexao();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("DELETE FROM [INVESTX].[dbo].[cliente]" + " where cpf= " + cpf);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    nossaconexao.Close();
                }
            }
        }

        private string RetornaStringDeConexao()
        {
            var connection = "Data Source = localhost,1433;Database=INVESTX;user id = sa; password=SApas@123;";
            return connection;
        }
    }
}
