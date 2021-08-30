using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    interface IFilmeRepository
    {
        /// <summary>
        /// Retorna todos os filmes
        /// </summary>
        /// <returns>Retorna uma lista de filmes</returns>
        List<FilmeDomain> ListarTodas();

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Um objeto novoFilme com os as informações que serão cadastradas</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Atualiza as informações de um filme passando o id pela requisição
        /// </summary>
        /// <param name="filme">Um objeto do tipo filme com os novos dados que serão cadastrados</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza as informações de um filme passando o id pela URL
        /// </summary>
        /// <param name="idFilme">O id do filme que será atualizado</param>
        /// <param name="filme"> O objeto do tipo filme com os novos dados que serão cadastrados</param>
        void AtualizarIdUrl(int idFilme, FilmeDomain filme);

        /// <summary>
        /// Busca um filme através do seu id
        /// </summary>
        /// <param name="idFilme">id do filme que será encontrado</param>
        void BuscarPorId(int idFilme);

        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="idFilme">id de um filme que será deletado</param>
        void Deletar(int idFilme);
    }
}
