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
        public IActionResult Atualizar(Pecas peca)
        {
            try
            {
                if (PecaRepository.BuscarPecasPorFornecedor(id) == null)
                    return NotFound();
                funcionario.FuncionarioId = id;
                FuncionarioRepository.Atualizar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}