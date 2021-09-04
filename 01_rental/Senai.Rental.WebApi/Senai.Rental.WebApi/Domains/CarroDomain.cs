using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class CarroDomain
    {
   
        public int idCarro { get; set; }

        public int idModelo { get; set; }
        
        public int idEmpresa { get; set; }

        public string placaCarro { get; set; }

        public ModeloDomain modelo { get; set; }

        public EmpresaDomain empresa { get; set; }

    }
}
