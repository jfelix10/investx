using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investx.Infra
{
    class PapelXRepository
    {
        public void Delete(int id)
        {
            var enderecoConexao = GetConnection();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("DELETE FROM [dbinvestimento1].[dbo].[papel]" + " where id= " + @id);
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
        public void Inserir(Papel papel)
        {
            var enderecoConexao = GetConnection();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("INSERT INTO [dbinvestimento1].[dbo].[papel] VALUES ('" + papel.ticker + "','" + papel.nome + "','" + papel.ativo + "');");
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
        public List<Papel> ListarPapeis()
        {
            var enderecoConexao = GetConnection();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    var papeis = nossaconexao.Query<Papel>("SELECT * FROM [dbinvestimento1].[dbo].[Papel];").AsList();

                    return papeis;
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
