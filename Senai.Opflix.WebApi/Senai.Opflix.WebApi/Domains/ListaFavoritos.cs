using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Domains
{
    public class ListaFavoritos
    {
        public int IdUsuario { get; set; }
        public Usuarios Usuario { get; set; }

        public int IdLancamento { get; set; }
        public Lancamentos Lancamentos { get; set; }
    }
}
