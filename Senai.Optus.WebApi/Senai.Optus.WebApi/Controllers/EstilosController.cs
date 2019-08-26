using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstiloRepository estiloRepository = new EstiloRepository();
        
        [HttpPost]
        public IActionResult Cadastrar(Estilos estilo)
        {
            try
            {
                estiloRepository.Cadastrar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih truta, deu pau" + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(estiloRepository.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos estilo = estiloRepository.BuscarPorID(id);
            if (estilo == null)
            {
                return NotFound();
            }
            return Ok(estilo);
        }
        [HttpPut]
       public IActionResult Atualizar(Estilos estilo)
        {
            try
            {
                Estilos EstiloBuscado = estiloRepository.BuscarPorID(estilo.IdEstilo);
                if (EstiloBuscado == null)
                {
                    return NotFound();
                }
                estiloRepository.Atualizar(estilo);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id) {
            estiloRepository.Deletar(id);
            return Ok();
        }
    }
}