using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investx.Infra
{
    class CarteiraXRepository
    {
        public void Delete(int id){
            var enderecoConexao = GetConnection();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("DELETE FROM [dbinvestimento1].[dbo].[carteira]" + " where id= " + @id);
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
        public void Inserir(Carteira carteira)
        {
                var enderecoConexao = GetConnection();
                using (var nossaconexao = new SqlConnection((string)enderecoConexao))
                {
                    try
                    {
                        nossaconexao.Open();
                        nossaconexao.Execute("INSERT INTO [dbinvestimento1].[dbo].[Carteira] VALUES ('" + carteira.idCliente + "','" + carteira.idCategoriaInvestimento + "','" + carteira.idPapel + "','" + carteira.ativo + "','" + carteira.qtPapel + "');");
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
        public List<Carteira> ListarCarteira(Cliente cliente)
        {
            var enderecoConexao = GetConnection();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    var carteiras = nossaconexao.Query<Carteira>("SELECT * FROM [dbinvestimento1].[dbo].[Carteira] where '" + cliente.cpf + "';").AsList();

                    return carteiras;
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
