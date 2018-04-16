using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;

namespace GestaoCondominio.Controllers
{
    [Route("api/[controller]")]
    public class MoradorController : Controller
    {
        private readonly ApiContext _context;

        public MoradorController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Morador> GetAll()
        {
            return _context.Moradores.ToList();
        }

        [HttpGet("{id}", Name = "GetMorador")]
        public IActionResult GetById(int id)
        {
            var item = _context.Moradores.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Morador item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Moradores.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMorador", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Morador item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var morador = _context.Moradores.FirstOrDefault(t => t.Id == id);
            if (morador == null)
            {
                return NotFound();
            }

            morador.Nome = item.Nome;
            morador.CPF = item.CPF;
            morador.CPF = item.CPF;
            morador.Fone = item.Fone;

            _context.Moradores.Update(morador);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var morador = _context.Moradores.FirstOrDefault(t => t.Id == id);
            if (morador == null)
            {
                return NotFound();
            }

            _context.Moradores.Remove(morador);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
