using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface ICarroRepository
    {
        //Essa API deve contar todos os métodos básicos para um CRUD simples.
        //listar, buscar por id, deletar, atualizar e inserir;

        /// <summary>
        /// Lista todos os carros
        /// </summary>
        /// <returns> uma lista de carros</returns>
        List<CarroDomain> ListarTodos();

        /// <summary>
        /// busca um carro pelo id
        /// </summary>
        /// <param name="id">id do carro</param>
        /// <returns>o carro correpondente com o id passado</returns>
        CarroDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta um carro
        /// </summary>
        /// <param name="id">id do carro que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// atualiza um carro pelo o id
        /// </summary>
        /// <param name="id">id do cliente que será deletado</param>
        /// <param name="carro">objeto do carro que contém os restantes dos dados para serem atualizados</param>
        void AtualizarPorId(int id, CarroDomain carro);

        /// <summary>
        /// Cadastra um novo carro
        /// </summary>
        /// <param name="novoCarro"></param>
        void Cadastrar(CarroDomain novoCarro);
    }
}
