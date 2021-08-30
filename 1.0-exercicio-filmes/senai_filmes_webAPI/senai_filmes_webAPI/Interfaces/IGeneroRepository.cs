using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface resposável por Genero Repository
    /// </summary>
   
    interface IGeneroRepository
    {
        /// <summary>
        /// Retorna todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="idGenero">O id do gênero que será buscado</param>
        /// <returns>Um objeto do tipo GeneroDomain que foi buscado</returns>
        GeneroDomain BuscarPorId(int idGenero);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="noveGenero"> Objeto novoGenero com os dados com os dados que serão cadastrados</param>
        void Cadastrar(GeneroDomain noveGenero);

        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com os novos dados</param>
        /// ex: http://localhost:500/api/generos
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um gênero existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idGenero">O id do genero que será atualizado</param>
        /// <param name="genero">Objeto genero com os novos dados</param>
        /// ex: http://localhost:500/api/generos/4
        void AtualizarIdUrl(int idGenero, GeneroDomain genero);

        /// <summary>
        /// Deleta um gênero
        /// </summary>
        /// <param name="idGenero">id do gênero que será deletado</param>
        void Deletar(int idGenero);
    }
}
