﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ClienteDomain
    {
        public int idCliente { get; set; }

        public string nomeCliente { get; set; }

        public string sobreNomeCliente { get; set; }

        public string cnh { get; set; } 
    }
}
