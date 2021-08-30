using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Controllers
{

    /// <summary>
    /// Define o recurso a através da url para que tenhamos uma alta coesão e facilidade da utilização da api a longo prazo.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        /// <summary>
        ///  Objeto da classe IFilmeRepository que irá receber os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }
        

        /// <summary>
        /// a cada vez que o controller for acionado uma instancia de FilmeRepository será criada e atribuirá os métodos que estão no repositório.
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Definindo o tipo da aquisição através do verbo.
        /// </summary>
        /// <returns>Um status code junto com uma list de filmes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            ///aqui é necessário uma lista porque a função retorna uma lista de objetos, ou seja devemos armazenar esses objetos em uma lita de objetos.
            List<FilmeDomain> listaFilme=_filmeRepository.ListarTodas();

            return Ok(listaFilme);

        }


        [HttpPost]
        public IActionResult Post (FilmeDomain novoFilme)
        {
            _filmeRepository.Cadastrar(novoFilme);

            return StatusCode(201);
        }


        /// <summary>
        /// esse endpoint deleta um item 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>um status code de conclusão</returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete (int id)
        {

            _filmeRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
