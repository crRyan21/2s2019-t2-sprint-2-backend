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
    public class CargosController : ControllerBase
    {
        CargoRepository CargoRepository = new CargoRepository();

        [Authorize]
        [HttpGet]
        public IEnumerable<Cargos> Listar()
        {
            return CargoRepository.Listar();
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            // lista fixa
            // EstiloDomain Estilo = estilos.Find(x => x.IdEstilo == id);

            // do banco de dados
            Cargos Cargo = CargoRepository.BuscarPorId(id);
            if (Cargo == null)
            {
                return NotFound();
            }
            return Ok(Cargo);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Cargos cargo)
        {
            CargoRepository.Cadastrar(cargo);
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Cargos cargo)
        {
            cargo.IdCargo = id;
            CargoRepository.Alterar(cargo);
            return Ok();
        }
    }
}