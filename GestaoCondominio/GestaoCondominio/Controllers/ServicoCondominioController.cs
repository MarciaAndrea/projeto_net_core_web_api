using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;

namespace GestaoCondominio.Controllers
{
    [Route("api/[controller]")]
    public class ServicoCondominioController : Controller
    {
        private readonly ApiContext _context;

        public ServicoCondominioController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ServicoCondominio> GetAll()
        {
            return _context.ServicoCondominios.ToList();
        }

        [HttpGet("{id}", Name = "GetServicoCondominio")]
        public IActionResult GetById(int id)
        {
            var item = _context.ServicoCondominios.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]ServicoCondominio item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.ServicoCondominios.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetServicoCondominio", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ServicoCondominio item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var servicoCondominio = _context.ServicoCondominios.FirstOrDefault(t => t.Id == id);
            if (servicoCondominio == null)
            {
                return NotFound();
            }

            _context.ServicoCondominios.Update(servicoCondominio);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var servicoCondominio = _context.ServicoCondominios.FirstOrDefault(t => t.Id == id);
            if (servicoCondominio == null)
            {
                return NotFound();
            }

            _context.ServicoCondominios.Remove(servicoCondominio);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
