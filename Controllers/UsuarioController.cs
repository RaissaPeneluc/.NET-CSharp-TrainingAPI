using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModuloAPI.bin.Controllers
{
    [ApiController]
    [Route("[controller]")]

    // Ponto de entrada disponibilizado nos métodos
    public class UsuarioController : ControllerBase
    {
        [HttpGet("ObterDataHoraAtual")]
        public IActionResult ObterDataHora(){
            var obj = new{
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString()
            };

            return Ok(obj);
        }

        [HttpGet("Apresentar/{nome}")]
        public IActionResult Apresentar(string nome){
            var mensagem = $"Olá {nome}, seja bem vinda!";
            return Ok (new {mensagem});
        }
        
    }
}