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

    //define que a resposta da api será em formato json (JavaScript Object Notation)
    [Produces("application/json")]


    //api/carros
    ///define a rota e o controler que será utilizado
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        //objeto do tipo ICarroRepository que vai receber os métodos da CarroRepository
        private ICarroRepository _carroRepository;

        //método construtor que vai ser iniciado quando o controller foi feito
        public CarrosController()
        {
            _carroRepository = new CarroRepository();
        }

        //GET
        [HttpGet]
        public IActionResult Read()
        {
            //lista que recebe o retorno da lista no método
            List<CarroDomain> carros = _carroRepository.ListarTodos();

            return Ok(carros);
        }

        //GET
        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            //cria um objeto que vai receber o retorno do método
            CarroDomain carro = _carroRepository.BuscarPorId(id);

            //verificação para ver se o objeto está nulo ou não
            if (carro == null)
            {
                return NotFound(
                new
                {
                    mensagem = "Registro de carro não encontrado",
                    erro = true
                }
                );
            }

            return Ok(carro);
        }

        //POST
        [HttpPost]
        public IActionResult Create (CarroDomain novoCarro)
        {
            //verificação simples para ver se o objeto passado não está vazio.
            if (novoCarro == null)
            {
                return BadRequest
                    (
                    new
                    {
                        mensagem = "Objeto vazio",
                        erro = true
                    }

                    );
            }

            _carroRepository.Cadastrar(novoCarro);
            return Ok(novoCarro);
        }




        ////DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //instância criada para armazenar o retorno do método
            CarroDomain carro = _carroRepository.BuscarPorId(id);


            //verificação para ver se o objeto retornado não é nulo
            if (carro == null)
            {
                return NotFound(
                    new
                    {

                        mensagem = "Registro de carro não encontrado",
                        erro = true
                    }

                    );
            }

            // tentativa de deletar caso seja bem sucedida, caso não seja, retornará um erro.
            try
            {
                _carroRepository.Deletar(id);

                return StatusCode(200);
            }
            catch (Exception error)
            {
                return BadRequest(error);

            }
        }

       //UPDATE
       [HttpPut("{id}")]
       public IActionResult Update (int id, CarroDomain carro)
        {
            CarroDomain carroAchado = _carroRepository.BuscarPorId(id);

            if (carroAchado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Registro de carro não encontrado",
                        erro = true
                    }

                    );
            }


            try
            {
                _carroRepository.AtualizarPorId(id, carro);

                return NoContent();
            }
            catch (Exception error)
            {
               return BadRequest(error);
            }
        }


        
    }
}
