using System;
using System.Collections.Generic;

namespace Senai.Opflix.WebApi.Domains
{
    public partial class Plataformas
    {
        public Plataformas()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int IdPlataform { get; set; }
        public string Nome { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
