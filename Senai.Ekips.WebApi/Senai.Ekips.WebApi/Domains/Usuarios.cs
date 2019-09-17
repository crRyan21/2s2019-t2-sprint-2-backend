using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdPermissao { get; set; }
        [Required(ErrorMessage = "A permissão é obrigatória.")]
        public string Permissao { get; set; }

        public Permissao IdPermissaoNavigation { get; set; }
        public ICollection<Funcionarios> Funcionarios { get; set; }

        public static implicit operator Usuarios(UsuarioRepository v)
        {
            throw new NotImplementedException();
        }
    }
}
