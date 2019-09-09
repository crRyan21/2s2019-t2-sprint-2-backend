using System;
using System.Collections.Generic;

namespace Senai.Opflix.WebApi.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public int? IdTipoUser { get; set; }
        public string Permissao { get; set; }
        public List<ListaFavoritos> ListaFavoritos { get; set; }

        public TipoUser IdTipoUserNavigation { get; set; }
    }
}
