using System;
using System.Collections.Generic;

namespace Senai.Opflix.WebApi.Domains
{
    public partial class TipoUser
    {
        public TipoUser()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipoUser { get; set; }
        public string Nome { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
