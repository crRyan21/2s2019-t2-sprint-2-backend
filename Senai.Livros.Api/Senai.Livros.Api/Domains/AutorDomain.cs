using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Livros.Api.Domains
{
    public class AutorDomain
    {
        public int IdAutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
