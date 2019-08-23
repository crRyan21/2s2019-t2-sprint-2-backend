using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Livros.Api.Domains
{
    public class LivroDomain
    {
        public int IdLivro { get; set; }

        public string Descricao { get; set; }

        public AutorDomain Autor { get; set; }
        public int AutorId { get; set; }

        public GeneroDomain Genero { get; set; }
        public int GeneroId { get; set; }
    }
}
