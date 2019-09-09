using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é requerido.")]
        public string Email { get; set; }
        [StringLength(200, MinimumLength = 3, ErrorMessage = "A senha é requerida e deve conter no mínimo 3 caracteres.")]
        public string Senha { get; set; }
    }
}
