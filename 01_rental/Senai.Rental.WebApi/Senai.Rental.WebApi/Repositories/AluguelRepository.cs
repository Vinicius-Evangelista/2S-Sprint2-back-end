using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        const string STRINGCONEXAO = @"Data Source=DESKTOP-DHSRSVI\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizarPorId(int id, AluguelDomain aluguel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string queryUpdate = "UPDATE ALUGUEL SET dataAluguel = @dataAluguel WHERE idAluguel = @idAluguel";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@dataAluguel", aluguel.dataAluguel);
                    sqlCommand.Parameters.AddWithValue("@idAluguel", id);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                sqlConnection.Open();

                string querySelectWhere = "SELECT * FROM ALUGUEL WHERE idAluguel = @idAluguel ;";

                SqlDataReader reader;

                using (SqlCommand sqlCommand = new SqlCommand(querySelectWhere, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@idAluguel", id);
                   reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(reader[0]),
                            idCarro = Convert.ToInt32(reader[1]),
                            idCliente = Convert.ToInt32(reader[2]),
                            dataAluguel = Convert.ToDateTime(reader[3])
                        };

                        return aluguel;
                    }

                    return null;
                }

            }

            
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {

            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string queryInsert = "INSERT INTO ALUGUEL (idCarro, idCliente, dataAluguel) VALUES(@idCarro, @idCliente, @dataAluguel);";

                sqlConnection.Open();

                using (SqlCommand sqlCmd = new SqlCommand(queryInsert,sqlConnection))
                {
                    sqlCmd.Parameters.AddWithValue("@idCarro", novoAluguel.idCarro);
                    sqlCmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    sqlCmd.Parameters.AddWithValue("@dataAluguel", novoAluguel.dataAluguel);
                    sqlCmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel;";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@idAluguel",id);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAluguel = new List<AluguelDomain>();

            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO)) 
            {
                string querySelectAll = 
@"SELECT idAluguel, r.idCarro, c.idCliente, r.placaCarro, nomeModelo, c.nomeCliente, dataAluguel 
FROM ALUGUEL
JOIN CLIENTE c
ON ALUGUEL.idCliente = c.idCliente
JOIN CARRO r
ON ALUGUEL.idCarro = r.idCarro
JOIN MODELO
ON MODELO.idModelo = r.idModelo";

                sqlConnection.Open();

                SqlDataReader reader;

                using (SqlCommand sqlCommand = new SqlCommand(querySelectAll, sqlConnection))
                {
                    reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {

                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(reader[0]),
                            idCarro = Convert.ToInt32(reader[1]),
                            idCliente = Convert.ToInt32(reader[2]),
                            dataAluguel = Convert.ToDateTime(reader[6]),
                            carro = new CarroDomain()
                            {
                                placaCarro = reader[3].ToString(),
                                modelo = new ModeloDomain()
                                {
                                    nomeModelo = reader[4].ToString(),
                                }
                            },
                            cliente = new ClienteDomain()
                            {
                                nomeCliente = reader[5].ToString(),
                            }
                        };

                        listaAluguel.Add(aluguel);
                    }
                }
            }

            return listaAluguel;
        }
    }
}
