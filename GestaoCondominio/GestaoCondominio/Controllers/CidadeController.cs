using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;


namespace GestaoCondominio.Controllers
{
    [Route("api/[controller]")]
    public class CidadeController : Controller
    {
        private readonly ApiContext _context;

        public CidadeController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Cidade> GetAll()
        {
            return _context.Cidades.ToList();
        }

        [HttpGet("{id}", Name = "GetCidade")]
        public IActionResult GetById(int id)
        {
            var item = _context.Cidades.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Cidade item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Cidades.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCidade", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Cidade item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var cidade = _context.Cidades.FirstOrDefault(t => t.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }

            cidade.Nome = item.Nome;


            _context.Cidades.Update(cidade);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cidade = _context.Cidades.FirstOrDefault(t => t.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }

            _context.Cidades.Remove(cidade);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
