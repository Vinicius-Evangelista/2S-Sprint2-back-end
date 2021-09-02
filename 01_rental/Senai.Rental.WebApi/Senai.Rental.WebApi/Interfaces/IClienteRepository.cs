using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IClienteRepository
    { //Essa API deve contar todos os métodos básicos para um CRUD simples.
      //listar, buscar por id, deletar, atualizar e inserir;
        
        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns> uma lista de cliente</returns>
        List<ClienteDomain> ListarTodos();

        /// <summary>
        /// busca um cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns>o cliente correpondente com o id passado</returns>
        ClienteDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        /// <param name="id">id do cliente que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// atualiza um cliente pelo o id
        /// </summary>
        /// <param name="id">id do cliente que será deletado</param>
        /// <param name="cliente">objeto do cliente que contém os restantes dos dados para serem atualizados</param>
        void AtualizarPorId(int id, ClienteDomain cliente);

        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <param name="novoCliente"></param>
        void Cadastrar(ClienteDomain novoCliente);
    }
}
