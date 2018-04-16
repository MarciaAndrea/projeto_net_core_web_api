using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;


namespace GestaoCondominio.Controllers
{
    [Route("api/[controller]")]
    public class ApartamentoCondominioController : Controller
    {
        private readonly ApiContext _context;

        public ApartamentoCondominioController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ApartamentoCondominio> GetAll()
        {
            return _context.ApartamentoCondominios.ToList();
        }

        [HttpGet("{id}", Name = "GetApartamentoCondominio")]
        public IActionResult GetById(int id)
        {
            var item = _context.ApartamentoCondominios.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]ApartamentoCondominio item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.ApartamentoCondominios.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetApartamentoCondominio", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ApartamentoCondominio item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var apartamentoCondominio = _context.ApartamentoCondominios.FirstOrDefault(t => t.Id == id);
            if (apartamentoCondominio == null)
            {
                return NotFound();
            }


            _context.ApartamentoCondominios.Update(apartamentoCondominio);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var apartamentoCondominio = _context.ApartamentoCondominios.FirstOrDefault(t => t.Id == id);
            if (apartamentoCondominio == null)
            {
                return NotFound();
            }

            _context.ApartamentoCondominios.Remove(apartamentoCondominio);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
