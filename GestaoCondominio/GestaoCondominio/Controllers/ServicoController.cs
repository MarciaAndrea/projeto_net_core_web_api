using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;

namespace GestaoCondominio.Controllers
{
    [Route("api/[controller]")]
    public class ServicoController : Controller
    {
        private readonly ApiContext _context;

        public ServicoController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Servico> GetAll()
        {
            return _context.Servicos.ToList();
        }

        [HttpGet("{id}", Name = "GetServico")]
        public IActionResult GetById(int id)
        {
            var item = _context.Servicos.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Servico item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Servicos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetServico", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Servico item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var servico = _context.Servicos.FirstOrDefault(t => t.Id == id);
            if (servico == null)
            {
                return NotFound();
            }

            servico.Nome = item.Nome;
            servico.Valor = item.Valor;
            servico.Rateio = item.Rateio;

            _context.Servicos.Update(servico);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var servico = _context.Servicos.FirstOrDefault(t => t.Id == id);
            if (servico == null)
            {
                return NotFound();
            }

            _context.Servicos.Remove(servico);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
