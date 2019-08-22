using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repository;


namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        FilmeRepository FilmeRepository = new FilmeRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FilmeRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filme)
        {
            try{
                FilmeRepository.Cadastrar(filme);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro." + ex.Message });
            }
            

        }

    }
}
