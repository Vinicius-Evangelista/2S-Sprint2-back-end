using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        const string STRINGCONEXAO = @"Data Source=DESKTOP-DHSRSVI\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizarPorId(int id, CarroDomain carro)
        {
            throw new NotImplementedException();
        }

        public CarroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(CarroDomain novoCarro)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarroDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
