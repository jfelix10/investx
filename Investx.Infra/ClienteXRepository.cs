using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Investx.Infra
{
    public class ClienteXRepository
    {
        public void Delete(int id)
        {
            var enderecoConexao = GetConnection();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("DELETE FROM [dbinvestimento1].[dbo].[cliente]" + " where id= " + @id);
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

        public void Inserir([FromForm] Cliente cliente)
        {
            if (!string.IsNullOrEmpty(cliente.email))
            {
                var enderecoConexao = GetConnection();
                using (var nossaconexao = new SqlConnection((string)enderecoConexao))
                {
                    try
                    {
                        nossaconexao.Open();
                        nossaconexao.Execute("INSERT INTO [dbinvestimento1].[dbo].[cliente] VALUES ('" + cliente.nome + "','" + cliente.cpf + "','" + cliente.rg + "','" + cliente.ativo + "','" + cliente.email + "','" + cliente.senha + "','" + cliente.tipo +"');");
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

        }

        public List<Cliente> RecuperarClientes()
        {
            var enderecoConexao = GetConnection();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    var investidores = nossaconexao.Query<Cliente>("SELECT * FROM [dbinvestimento1].[dbo].[Cliente]").AsList();
                    
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

        public Cliente RecuperarCliente(string cpf) {
            var enderecoConexao = GetConnection();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    var clientes = nossaconexao.Query<Cliente>("SELECT * FROM [dbinvestimento1].[dbo].[Cliente]" + " where cpf= " + cpf).AsList();

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

        public void Atualizar(Cliente cliente, int id)

        {
            var enderecoConexao = GetConnection();

            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("UPDATE [dbinvestimento1].[dbo].[cliente] " + "set nome = '" + cliente.nome + "' where id = " + id);
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

        private object GetConnection()
        {
            var connection = "Data Source = LENOVO-PC\\SQLEXPRESS;Database=dbinvestimento1;user id = sa; password=12345;";
            return connection;
        }
    }
}
