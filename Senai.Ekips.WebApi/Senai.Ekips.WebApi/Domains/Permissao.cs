using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Permissao
    {
        public Permissao()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdPermissao { get; set; }
        public string Nome { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
