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
    public class GenerosController : ControllerBase
    {
        GeneroRepository generoRepository = new GeneroRepository();

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain genero)
        {
            generoRepository.Cadastrar(genero);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<GeneroDomain> Listar()
        {
            return generoRepository.Listar();
        }
    }
}