using System;
using System.Collections.Generic;

namespace Senai.Opflix.WebApi.Domains
{
    public partial class TipoTitulo
    {
        public TipoTitulo()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int IdTipoTitulo { get; set; }
        public string Nome { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
