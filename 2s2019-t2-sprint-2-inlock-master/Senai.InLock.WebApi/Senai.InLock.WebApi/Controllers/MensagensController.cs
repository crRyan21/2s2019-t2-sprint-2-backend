using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MensagensController : ControllerBase
    {
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet ("ADMINISTRADOR")]
        public IActionResult Mensagem()
        {
            return Ok(new { mensagem = "Sucesso" });
        }

    }
}