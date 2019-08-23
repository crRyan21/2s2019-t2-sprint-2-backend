using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Livros.Api.Domains;
using Senai.Livros.Api.Repository;

namespace Senai.Livros.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        AutorRepository autorRepository = new AutorRepository();

        [HttpPost]
        public IActionResult Cadastrar(AutorDomain autor)
        {
            autorRepository.Cadastrar(autor);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<AutorDomain> Listar()
        {
            return autorRepository.Listar();
        }
    }
}