using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Interfaces;
using Senai.Opflix.WebApi.Repositories;
namespace Senai.Opflix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        public ILancamentoRepository LancamentoRepository { get; set; }

        public LancamentosController()
        {
            LancamentoRepository = new LancamentoRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamento)
        {
            try
            {
                LancamentoRepository.Cadastrar(lancamento);
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
            return Ok(LancamentoRepository.Listar());
        }
        [Authorize]
        [HttpGet("data")]
        public IActionResult ListarPorData()
        {
            return Ok(LancamentoRepository.ListarPorData());
        }
        [Authorize]
        [HttpGet("plataforma")]
        public IActionResult FiltrarPorMidia()
        {
            return Ok(LancamentoRepository.FiltrarPorMidia());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Lancamentos lancamento = LancamentoRepository.BuscarPorId(id);
                if (lancamento == null)
                    return NotFound();
                return Ok(lancamento);
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
                if (LancamentoRepository.BuscarPorId(id) == null)
                    return NotFound();
                LancamentoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Lancamentos lancamento, int id)
        {
            try
            {
                Lancamentos lancamentoBuscado = LancamentoRepository.BuscarPorId(id);
                if (lancamentoBuscado == null)
                    return NotFound();
                LancamentoRepository.Atualizar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize]
        [HttpPost("favorito")]
        public IActionResult CadastrarFavorito(ListaFavoritos favorito)
        {
            string sucesso = "Deu certo cachorro";
            try
            {
                LancamentoRepository.CadastrarFavorito(favorito);
                return Ok(sucesso);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize]
        [HttpGet("favorito")]
        public IActionResult ListarFavoritos()
        {

            //var identity = HttpContext.User.Identity as ClaimsIdentity;
            //identity.Claims.First();

            string permissao = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
            if (permissao == "ADMINISTRADOR")
                return Ok(LancamentoRepository.ListarFavoritos());
            else if (permissao == "COMUM")
                return Ok(LancamentoRepository.BuscarFavoritoPorUsuario(Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value)));
            else
                return Forbid();
        }
    }
}