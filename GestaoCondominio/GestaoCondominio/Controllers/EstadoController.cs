using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;

namespace GestaoCondominio.Controllers
{
    [Route("api/[controller]")]
    public class EstadoController : Controller
    {
        private readonly ApiContext _context;

        public EstadoController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Estado> GetAll()
        {
            return _context.Estados.ToList();
        }

        [HttpGet("{id}", Name = "GetEstado")]
        public IActionResult GetById(int id)
        {
            var item = _context.Estados.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Estado item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Estados.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetEstado", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Estado item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var estado = _context.Estados.FirstOrDefault(t => t.Id == id);
            if (estado == null)
            {
                return NotFound();
            }

            estado.Nome = item.Nome;
            estado.UF = item.UF;

            _context.Estados.Update(estado);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var estado = _context.Estados.FirstOrDefault(t => t.Id == id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(estado);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
