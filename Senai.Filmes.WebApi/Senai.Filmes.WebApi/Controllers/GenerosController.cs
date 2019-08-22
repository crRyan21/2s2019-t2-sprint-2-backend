using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repository;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository generoRepository = new GeneroRepository();

        [HttpGet]
        public IEnumerable<GeneroDomain> Listar()
        {
            //return generos
            return generoRepository.Listar();
        }
        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            generoRepository.Cadastrar(generoDomain);
            return Ok();
        }

        public IActionResult Alterar(GeneroDomain generoDomain)
        {
            generoRepository.Alterar(generoDomain);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            GeneroDomain generoDomain = generoRepository.BuscarPorId(id);
            if (generoDomain == null)
            {
                return NotFound();
            }
            return Ok(generoDomain);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            generoRepository.Deletar(id);
            return Ok();
        }
    }
}