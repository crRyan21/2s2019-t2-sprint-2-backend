using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]  
    [ApiController]
    public class EstilosController : ControllerBase
    {
        List<EstiloDomain> estilos = new List<EstiloDomain>()
        {
            new EstiloDomain { IdEstilo = 1, Nome = "Rock" }
            ,new EstiloDomain { IdEstilo = 2, Nome = "Pop" }
        };

        EstiloRepository EstiloRepository = new EstiloRepository();

        [HttpGet]
        public IEnumerable<EstiloDomain> Listar()
        {
            // return estilos;
            return EstiloRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            //buscando a lista do banco de dados
            EstiloDomain Estilo = EstiloRepository.BuscarPorId(id);
            if (Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo);
        }

        //[HttpPost]
       // public IActionResult Cadastrar(EstiloDomain estiloDomain)
       // {
        //    estilos.Add(new EstiloDomain
        //    {
        //        IdEstilo = estilos.Count + 1,
        //        Nome = estiloDomain.Nome }
        //    );
        //    return Ok(estilos);
       // }

        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Cadastrar(estiloDomain);
            return Ok();
        }

        public IActionResult Atualizar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Alterar(estiloDomain);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }

        //[HttpGet]
        //public string Get()
        //{
        //    return "Requisição Recebida";
        //}

    }
}