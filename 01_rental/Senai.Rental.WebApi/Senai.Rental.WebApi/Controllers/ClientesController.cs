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

    /// <summary>
    /// informando que a api vai receber e retornar em JSON (JavaScript Object Notation)
    /// </summary>
    [Produces("application/json")]

    ///Definindo a rota para acessar a api
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        public ClientesController()
        {
            _clienteRepository = new ClienteRepository();
        }

        //GET
        [HttpGet]
        public IActionResult Read()
        {
            //lista que recebe o retorno do método
            List<ClienteDomain> listaCliente = _clienteRepository.ListarTodos();

            return Ok(listaCliente);
        }

        //GET
        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            ClienteDomain carro = _clienteRepository.BuscarPorId(id);

            if (carro == null)
            {
                return NotFound
                    (
                    new
                    {
                        mensagem = "O cliente não foi encontrado !",
                        erro = true
                    }

                    );
            }

            return Ok(carro);
        }

        //POST
        [HttpPost]
        public IActionResult Create(ClienteDomain novoCliente)
        {
            if (novoCliente != null)
            {
                _clienteRepository.Cadastrar(novoCliente);
                return StatusCode(201);
            }

            return BadRequest

                (
                new
                {
                    mensagem = "Objeto vazio !",
                    erro = true
                }
                );
        }


        //PUT
        [HttpPut("{id}")]
        public IActionResult Update(int id, ClienteDomain clienteUpdate)
        {
            ClienteDomain cliente = _clienteRepository.BuscarPorId(id);

            if (cliente == null)
            {
                return NotFound
                    (
                    new
                    {
                        mensagem = "Cliente não encontrado !",
                        erro = true
                    }

                    );
            }

            try
            {
                _clienteRepository.AtualizarPorId(id, clienteUpdate);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest

                    (
                    new
                    {
                        mensagem = "Algo deu errado, talve você tenha esquecido de colocar um objeto",
                        erro = true
                    }
                    );
            }

        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ClienteDomain cliente = _clienteRepository.BuscarPorId(id);

            if (cliente != null)
            {
                try
                {
                    _clienteRepository.Deletar(id);
                    return NoContent();
                }
                catch (Exception)
                {

                    BadRequest
                        (
                        new
                        {
                            mensagem = "Algo deu errado, no código na requisição !",
                            erro = true
                        }
                        );
                }
            }

            return NotFound
                (
                new
                {
                    mensagem = "O cliente informado não foi achado !",
                    erro = true
                }

                );
        }
    }
}

