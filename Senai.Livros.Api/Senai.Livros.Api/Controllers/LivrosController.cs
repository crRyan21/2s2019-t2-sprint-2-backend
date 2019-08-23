using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Livros.Api.Domains;
using Senai.Livros.Api.Repository;

namespace Senai.Livros.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        LivroRepository livroRepository = new LivroRepository();

        [HttpPost]
        public IActionResult Cadastrar(LivroDomain livro)
        {
            try
            {
                livroRepository.Cadastrar(livro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro." + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(livroRepository.Listar());
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            livroRepository.Deletar(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Atualizar(LivroDomain livro)
        {
            livroRepository.Alterar(livro);
            return Ok();
        }

    }
}