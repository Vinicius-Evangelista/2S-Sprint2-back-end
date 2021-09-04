using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        //string de conexão que contém o endereço para a conexão com o banco de dados.
        const string STRINGCONEXAO = @"Data Source=DESKTOP-DHSRSVI\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizarPorId(int id, ClienteDomain cliente)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string queryUpdate = "UPDATE CLIENTE SET nomeCliente = @nomeCliente, sobreNomeCliente = @sobreNomeCliente, cnh = @cnh WHERE idCliente = @idCliente";
                
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@nomeCliente", cliente.nomeCliente);
                    sqlCommand.Parameters.AddWithValue("@sobreNomeCliente", cliente.sobreNomeCliente);
                    sqlCommand.Parameters.AddWithValue("@cnh", cliente.cnh);
                    sqlCommand.Parameters.AddWithValue("@idCliente", cliente.idCliente);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int id)
        {

            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string querySelectById = "SELECT idCliente, nomeCliente, sobreNomeCliente, cnh FROM CLIENTE WHERE idCliente = @idCliente";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(querySelectById, sqlConnection))
                {

                    sqlCommand.Parameters.AddWithValue("@idCliente", id);
                    SqlDataReader reader =  sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain carro = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(reader[0]),
                            nomeCliente = reader[1].ToString(),
                            sobreNomeCliente = reader[2].ToString(),
                            cnh = reader[3].ToString()
                        };

                        return carro;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
               string  queryInsert = @"INSERT INTO CLIENTE (nomeCliente, sobreNomeCliente ,cnh) VALUES (@nomeCliente, @sobreNomeCliente, @cnh);";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    sqlCommand.Parameters.AddWithValue("@sobreNomeCliente", novoCliente.sobreNomeCliente);
                    sqlCommand.Parameters.AddWithValue("@cnh", novoCliente.cnh);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@idCliente", id);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaClinte = new List<ClienteDomain>();

            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string querySelectAll = "SELECT idCliente, nomeCliente, sobreNomeCliente, cnh FROM CLIENTE";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(querySelectAll, sqlConnection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        ClienteDomain novoCliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(reader[0]),
                            nomeCliente = reader[1].ToString(),
                            sobreNomeCliente = reader[2].ToString(),
                            cnh = reader[3].ToString()
                        };

                        listaClinte.Add(novoCliente);
                    }

                    return listaClinte; 
                }
            }
        }
    }
}
