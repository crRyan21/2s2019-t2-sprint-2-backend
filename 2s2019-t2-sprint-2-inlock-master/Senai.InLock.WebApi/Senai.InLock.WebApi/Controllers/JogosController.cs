using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModels;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        JogoRepository JogoRepository = new JogoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(JogoRepository.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Jogos jogos = JogoRepository.BuscarPorId(id);
                if (jogos == null)
                    return NotFound();
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Jogos jogos)
        {
            try
            {
                JogoRepository.Cadastrar(jogos);
                return Ok();
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
                if (JogoRepository.BuscarPorId(id) == null)
                    return NotFound();
                JogoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Jogos estudio, int id)
        {
            try
            {
                Jogos jogoBuscado = JogoRepository.BuscarPorId(id);
                if (jogoBuscado == null)
                    return NotFound();
                JogoRepository.Atualizar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize]
        [HttpGet("data")]
        public IActionResult ListarPorData()
        {
            return Ok(JogoRepository.ListarPorData());
        }
        [Authorize]
        [HttpGet("valor")]
        public IActionResult ListarPorValor()
        {
            return Ok(JogoRepository.ListarPorValor());
        }
        [Authorize]
        [HttpGet]
        public IActionResult BuscarPorNome(string nome)
        {
            try
            {
                Jogos jogos = JogoRepository.BuscarPorNome(nome);
                if (jogos == null)
                    return NotFound();
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }


    }
}