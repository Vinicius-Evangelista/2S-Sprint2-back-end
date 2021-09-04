using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Senai.Rental.WebApi.Controllers
{

    //Essa API deve contar todos os métodos básicos para um CRUD simples.
    //listar, buscar por id, deletar, atualizar e inserir;

    //define que reposta da api será em formato json (JavaScript Object Notation);
    [Produces("application/json")]

    //define a rota para acessar a api e o controller que será utilizado.
    [Route("api/[controller]")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        // Objeto _generoRepository que irá receber todos os metodos definidor na interface IGeneroRepository
        private IAluguelRepository _alugueisRepository;


        public AlugueisController()
        {
            _alugueisRepository = new AluguelRepository();
        }


        //GET
        [HttpGet]
        public IActionResult Read ()
        {
            //É necessário uma lista para receber os objetos que estão retornando pelo método
            List<AluguelDomain> listaAluguel = _alugueisRepository.ListarTodos();

            return Ok(listaAluguel);
        }

        //POST
        [HttpPost]
        public IActionResult Create(AluguelDomain novoAluguel)
        {
            //adiciona um novo aluguel
            _alugueisRepository.Cadastrar(novoAluguel);

            return StatusCode(201);
        }

        //GET
        [HttpGet("{id}")]

        public IActionResult ReadEspc (int id)
        {
            AluguelDomain aluguel = _alugueisRepository.BuscarPorId(id);

            return Ok(aluguel);

        }


        //PUT
        [HttpPut("{id}")]
        public IActionResult Put (int id, AluguelDomain aluguel)
        {
            AluguelDomain aluguelId = _alugueisRepository.BuscarPorId(id);

            if (aluguelId == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Aluguel não encontrado !",
                    erro = true
                    }

                    );
            }

            try
            {
                _alugueisRepository.AtualizarPorId(id, aluguel);

                return StatusCode(200);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            AluguelDomain aluguelId = _alugueisRepository.BuscarPorId(id);

            //fazendo verificação antes de executar o algoritimo
            if (aluguelId == null)
            {
                //return personalizando com mensagem de erro
                return NotFound(
                    new
                    {
                        mensagem = "O registro de aluguel não foi encontrado",
                        erro = true //Porque isso daqui está true ?
                    }

                    );
            }

            try
            {
                _alugueisRepository.Deletar(id);

                return StatusCode(200);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}
