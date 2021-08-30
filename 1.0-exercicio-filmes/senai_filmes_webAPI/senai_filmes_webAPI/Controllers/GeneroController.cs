using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Controller responsavel pelos endpoints referentes aos generos.
/// </summary>
namespace senai_filmes_webAPI.Controllers
{
    // define que o tipo de resposta da API será em formato json
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato de domínio/api/nomeController.
    //ex: http://localhost:5001/api/generos
    [Route("api/[controller]")]
    [ApiController]

    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os metodos definidor na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }


        /// <summary>
        /// Instancia um objeto GeneroRepository para que haja a referencia aos métodos no repositório
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            //Criar uma lista nomeada listaGeneros para receber.
            List<GeneroDomain> listaGenero = _generoRepository.ListarTodos();
            //Retorna o status code 200(OK) com alista de gêneros no formato JSON
            return Ok(listaGenero);
        }


        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            //variavel que contém a instancia de GeneroRepository para conseguir os métodos que estão nelas contidos.
            _generoRepository.Cadastrar(novoGenero);

            return StatusCode(201);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _generoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
