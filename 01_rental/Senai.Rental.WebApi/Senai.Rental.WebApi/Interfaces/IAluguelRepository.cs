using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {
        //Essa API deve contar todos os métodos básicos para um CRUD simples.
        //listar, buscar por id, deletar, atualizar e inserir;

        /// <summary>
        /// Lista todos os aluguéis
        /// </summary>
        /// <returns> uma lista de aluguéis</returns>
        List<AluguelDomain> ListarTodos();

        /// <summary>
        /// busca um aluguel pelo id
        /// </summary>
        /// <param name="id">id do aluguel</param>
        /// <returns>o aluguel correpondente com o id passado</returns>
        AluguelDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta um aluguel
        /// </summary>
        /// <param name="id">id do aluguel que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// atualiza um aluguel pelo o id
        /// </summary>
        /// <param name="id">id do aluguel que será deletado</param>
        /// <param name="aluguel">objeto do aluguel que contém os restantes dos dados para serem atualizados</param>
        void AtualizarPorId(int id, AluguelDomain aluguel);

        /// <summary>
        /// Cadastra um novo aluguel
        /// </summary>
        /// <param name="novoCliente"></param>
        void Cadastrar(AluguelDomain novoAluguel);
    }
}
