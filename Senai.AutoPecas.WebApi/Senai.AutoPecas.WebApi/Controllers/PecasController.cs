using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;


namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private IPecaRepository PecaRepository { get; set; }
        public PecasController()
        {
            PecaRepository = new PecaRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PecaRepository.BuscarPecasPorFornecedor(Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value)));
        }


        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Pecas peca)
        {
            try
            {
                PecaRepository.Cadastrar(peca);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Pecas pecas = PecaRepository.BuscarPecasPorId(id);

                if (pecas == null)
                    return NotFound();
                return Ok(pecas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,Pecas peca)
        {
            try
            {
                if (PecaRepository.BuscarPecasPorId(id) == null)
                    return NotFound();
                peca.PecaId = id;
                PecaRepository.Atualizar(peca);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                if (PecaRepository.BuscarPecasPorId(id) == null)
                    return NotFound();
                PecaRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}