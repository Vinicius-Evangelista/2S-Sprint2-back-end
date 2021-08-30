using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// const que contém o caminho para o banco de dados.
        /// </summary>
        const string STRINGCONEXAO = "Data Source=DESKTOP-DHSRSVI\\SQLEXPRESS; initial catalog=CATALOGO; user Id=sa; pwd=senai@132";


        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idFilme, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void BuscarPorId(int idFilme)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection sqlConnection = new SqlConnection (STRINGCONEXAO))
            {
                // em sql para declarar um parâmetro é só colocar o '@' na frente junto com o nome do atributo                
                string queryInsert = "INSERT INTO FILME (idGenero, tituloFilme) VALUES(@idGenero, @tituloFilme)";

                sqlConnection.Open();

                using (SqlCommand sqlCmd = new SqlCommand(queryInsert,sqlConnection))
                {
                    //Métodos que adicionam os valores dos objetos aos parâmetros.
                    sqlCmd.Parameters.AddWithValue("@idGenero", novoFilme.idGenero);
                    sqlCmd.Parameters.AddWithValue("@tituloFilme", novoFilme.tituloFilme);
                    sqlCmd.ExecuteNonQuery();


                };
            }
        }

        public void Deletar(int idFilme)
        {

            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO))       
            {
                // neste daqui só precisamos executar o código e não preciamos atribuir nada.
                 string queryDelete = $"DELETE FROM FILME WHERE idFilme = {idFilme} ";

                sqlConnection.Open();

                using (SqlCommand cmdText = new SqlCommand(queryDelete, sqlConnection))
                {

                    cmdText.ExecuteNonQuery();

                }
            }
        }

        public List<FilmeDomain> ListarTodas()
        { 
            ///lista para exibir todos os objetos de filme
            List<FilmeDomain> listaFilme = new List<FilmeDomain>();


            ///usar biblioteca que contém os scripts para se relacionar com o banco de dados.
            using (SqlConnection sqlConnection = new SqlConnection(STRINGCONEXAO)) 
            {
                ///comando para fazer conexão com o banco de dados.
                sqlConnection.Open();

                ///string contendo a query para rodar no banco de dados.
                string querySelectAll = "SELECT isnull(FILME.idGenero,0)[idGenero], idFilme, tituloFilme FROM FILME";

                ///tipo de variável que consegue retornar os dados que foram exibidos pelo sql
                SqlDataReader rdr;

                ///using para executar os camando em sql, junto com caminho
                using (SqlCommand cmd = new SqlCommand(querySelectAll, sqlConnection)) 
                {
                   ///rdr que lê dados em sql recebe o retorno da execução do comando
                   rdr = cmd.ExecuteReader();

                    /// laço de repetição para armazenar todos os dados em um lista
                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),
                            idFilme = Convert.ToInt32(rdr[1]),
                            tituloFilme = rdr[2].ToString(),
                        };

                        //adicionando os objetos de filme na lista de filme
                        listaFilme.Add(filme);
                        
                    }

                
                }


            }

             return listaFilme;
        }
    }
}
