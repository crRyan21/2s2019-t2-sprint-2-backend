using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        DepartamentoRepository DepartamentoRepository = new DepartamentoRepository();

        [Authorize]
        [HttpGet]
        public IEnumerable<Departamentos> Listar()
        {
            return DepartamentoRepository.Listar();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Departamentos departamento)
        {
            DepartamentoRepository.Cadastrar(departamento);
            return Ok();
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            // lista fixa
            // EstiloDomain Estilo = estilos.Find(x => x.IdEstilo == id);

            // do banco de dados
            Departamentos Departamento = DepartamentoRepository.BuscarPorId(id);
            if (Departamento == null)
            {
                return NotFound();
            }
            return Ok(Departamento);
        }
    }
}