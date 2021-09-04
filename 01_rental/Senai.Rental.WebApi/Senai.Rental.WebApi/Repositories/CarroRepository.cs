using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        const string STRINGCONEXAO = @"Data Source=DESKTOP-DHSRSVI\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        /// <summary>
        /// atualiza o registro de um carro
        /// </summary>
        /// <param name="id">id do carro que vai atualizado</param>
        /// <param name="carro"> objeto do carro por onde será passada as informações</param>
        public void AtualizarPorId(int id, CarroDomain carro)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string queryUptade = "UPDATE CARRO SET placaCarro = @placaCarro WHERE idCarro = @idCarro";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryUptade, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@placaCarro", carro.placaCarro);
                    sqlCommand.Parameters.AddWithValue("@idCarro", id);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// busca o registro de um carro por um id passado
        /// </summary>
        /// <param name="id">id do carro que será buscando</param>
        /// <returns></returns>
        public CarroDomain BuscarPorId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string querySelectWhere = @"
SELECT idCarro, m.idModelo, e.idEmpresa, placaCarro,nomeModelo, nomeEmpresa, nomeMarca
FROM CARRO
JOIN MODELO m
ON CARRO.idModelo = m.idModelo
JOIN MARCA
ON m.idMarca = MARCA.idMarca
JOIN EMPRESA e
ON CARRO.idEmpresa = e.idEmpresa
WHERE idCarro = @idCarro";

                sqlConnection.Open();

                SqlDataReader reader;

                using (SqlCommand sqlCommand = new SqlCommand(querySelectWhere, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@idCarro",id);
                    reader = sqlCommand.ExecuteReader();

                    // verificação para ver se existe algo no arquivo passado.
                    if (reader.Read())
                    {
                        //passando cada dado do objeto de maneira manual (é possivel ter um objeto dentro do outro)
                        CarroDomain carro = new CarroDomain()
                        {
                            idCarro = Convert.ToInt32(reader[0]),
                            idEmpresa = Convert.ToInt32(reader[1]),
                            idModelo = Convert.ToInt32(reader[2]),
                            placaCarro = reader[3].ToString(),
                            modelo = new ModeloDomain()
                            {
                                nomeModelo = reader[4].ToString(),
                                marca = new MarcaDomain()
                                {
                                    nomeMarca = reader[6].ToString()
                                }
                            },
                            empresa = new EmpresaDomain()
                            {
                                nomeEmpresa = reader[5].ToString()
                            }
                        };

                        return carro;
                    }

                    return null;

                }

            }

            
        }

        /// <summary>
        /// cadastra um novo carro 
        /// </summary>
        /// <param name="novoCarro">objeto contendo os dados do carro que será passado</param>
        public void Cadastrar(CarroDomain novoCarro)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string queryInsert = "INSERT INTO CARRO (placaCarro, idEmpresa, idModelo) VALUES(@placaCarro, @idEmpresa, @idModelo);";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert,sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@placaCarro", novoCarro.placaCarro);
                    sqlCommand.Parameters.AddWithValue("@idEmpresa", novoCarro.idEmpresa);
                    sqlCommand.Parameters.AddWithValue("@idModelo", novoCarro.idModelo);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                string queryDelete = "DELETE FROM CARRO WHERE idCarro = @idCarro";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@idCarro", id);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public List<CarroDomain> ListarTodos()
        {
            List<CarroDomain> listaCarro = new List<CarroDomain>();

            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))
            {
                sqlConnection.Open();

                string querySelectAll = @"SELECT idCarro, m.idModelo, e.idEmpresa, placaCarro,nomeModelo, nomeEmpresa, nomeMarca
FROM CARRO
JOIN MODELO m
ON CARRO.idModelo = m.idModelo
JOIN MARCA
ON m.idMarca = MARCA.idMarca
JOIN EMPRESA e
ON CARRO.idEmpresa = e.idEmpresa";



                SqlDataReader reader;

                using (SqlCommand sqlCommand = new SqlCommand(querySelectAll, sqlConnection))
                {
                    
                    reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        CarroDomain carro = new CarroDomain()
                        {
                            idCarro = Convert.ToInt32(reader[0]),
                            idEmpresa = Convert.ToInt32(reader[1]),
                            idModelo = Convert.ToInt32(reader[2]),
                            placaCarro = reader[3].ToString(),
                            modelo = new ModeloDomain()
                            {
                                nomeModelo = reader[4].ToString(),
                                marca = new MarcaDomain()
                                {
                                    nomeMarca = reader[6].ToString()
                                }
                            },
                            empresa = new EmpresaDomain()
                            {
                                nomeEmpresa = reader[5].ToString()
                            }
                        };

                        listaCarro.Add(carro);
                    }
                }
            }

            return listaCarro;
        }
    }
}
