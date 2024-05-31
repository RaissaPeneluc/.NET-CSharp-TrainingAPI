using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApi.Context;
using TrainingApi.Entities;

namespace TrainingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        // Insere informações na tabela
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }

        // Procura informações na tabela pelo ID
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contato.Find(id);

            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        // Atualiza informações na tabela
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contato.Find(id);

            if (contatoBanco == null)
            {
                return NotFound();
            }

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contato.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

    }
}