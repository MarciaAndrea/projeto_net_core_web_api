using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;

namespace GestaoCondominio.Controllers
{
    [Route("api/[controller]")]
    public class SindicoController : Controller
    {
        private readonly ApiContext _context;

        public SindicoController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Sindico> GetAll()
        {
            return _context.Sindicos.ToList();
        }

        [HttpGet("{id}", Name = "GetSindico")]
        public IActionResult GetById(int id)
        {
            var item = _context.Sindicos.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Sindico item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Sindicos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetSindico", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Sindico item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var sindico = _context.Sindicos.FirstOrDefault(t => t.Id == id);
            if (sindico == null)
            {
                return NotFound();
            }

            sindico.Nome = item.Nome;

            _context.Sindicos.Update(sindico);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sindico = _context.Sindicos.FirstOrDefault(t => t.Id == id);
            if (sindico == null)
            {
                return NotFound();
            }

            _context.Sindicos.Remove(sindico);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
