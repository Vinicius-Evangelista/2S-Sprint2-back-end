using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// string de conexao de banco dados que estabeleça os parâmetros
        /// Data Source = banco de dados
        /// initial catalog = SpMedicalGroup_T
        /// user Id = sa
        /// pwd = Senai@132
        /// </summary>
        const string _STRINGCONEXAO = "Data Source=NOTE0113E2\\SQLEXPRESS, initial catalog=SpMedicalGroup_T user Id=sa pwd=Senai@132";

        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idGenero)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();

            //passando uma conexão com o sql e informando o "caminho" para a conexão
            using (SqlConnection connectionSql= new SqlConnection(_STRINGCONEXAO))
            {
                //instrução a ser executada
                string querySelectAll = "SELECT idGenero, nomeGenero FROM situacao";

                // abre uma conexão com o banco de dados
                connectionSql.Open();

                
                // variável do tipo que lê uma os dados de uma tabela do banco de dados.
                SqlDataReader rdr;

                //Executar comando slq passando a query (consulta) junto com o comando para fazer a conexão.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, connectionSql))
                {
                    //faz a conexão com o servidor e executa a querySelectAll e armazena os dados que foram lidos no rdr.
                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {

                        GeneroDomain genero = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),

                            nomeGenero = rdr[1].ToString()

                        };

                        listaGenero.Add(genero);

                    };
                }
            }

            return listaGenero;
        }
    }
}
