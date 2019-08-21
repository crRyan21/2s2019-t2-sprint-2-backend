using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repository;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();


        [HttpGet]
        public IEnumerable<FuncionarioDomain> Listar()
        {
            return funcionarioRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionarioDomain funcionario = funcionarioRepository.BuscarPorId(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain funcionarioDomain)
        {
            funcionarioRepository.Cadastrar(funcionarioDomain);
            return Ok();
        }

        
        public IActionResult Atualizar(FuncionarioDomain funcionarioDomain)
        {
            funcionarioRepository.Alterar(funcionarioDomain);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepository.Deletar(id);
            return Ok();
        }

        public IActionResult AtualizarDataNascimento(FuncionarioDomain funcionarioDomain)
        {
            funcionarioRepository.AlterarDataNascimento(funcionarioDomain);
            return Ok();
        }
    }
}