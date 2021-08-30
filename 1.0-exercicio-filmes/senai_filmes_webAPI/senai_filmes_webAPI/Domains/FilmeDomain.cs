using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade FILME
    /// </summary>
    public class FilmeDomain { 
        [JsonIgnore]
        public GeneroDomain genero { get; set; }
        public int idFilme { get; set; }
        public int idGenero { get; set; }
        public string tituloFilme { get; set; }
    } 
}
