using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Interfaces;
using Senai.Opflix.WebApi.Repositories;


namespace Senai.Opflix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlataformasController : ControllerBase
    {
        public IPlataformaRepository PlataformaRepository { get; set; }

        public PlataformasController()
        {
            PlataformaRepository = new PlataformaRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataforma)
        {
            try
            {
                PlataformaRepository.Cadastrar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformaRepository.Listar());
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Plataformas plataformas = PlataformaRepository.BuscarPorId(id);
                if (plataformas == null)
                    return NotFound();
                return Ok(plataformas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                if (PlataformaRepository.BuscarPorId(id) == null)
                    return NotFound();
                PlataformaRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Plataformas plataforma, int id)
        {
            try
            {
                Plataformas plataformaBuscada = PlataformaRepository.BuscarPorId(id);
                if (plataformaBuscada == null)
                    return NotFound();
                PlataformaRepository.Atualizar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}