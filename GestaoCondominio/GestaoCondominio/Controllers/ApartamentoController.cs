using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;

namespace GestaoCondominio.Controllers
{
    [Route("api/[controller]")]
    public class ApartamentoController : Controller
    {
        private readonly ApiContext _context;

        public ApartamentoController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Apartamento> GetAll()
        {
            return _context.Apartamentos.ToList();
        }

        [HttpGet("{id}", Name = "GetApartamento")]
        public IActionResult GetById(int id)
        {
            var item = _context.Apartamentos.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Apartamento item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Apartamentos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetApartamento", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Apartamento item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var apartamento = _context.Apartamentos.FirstOrDefault(t => t.Id == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            apartamento.Apto = item.Apto;
            apartamento.Situacao = item.Situacao;


            _context.Apartamentos.Update(apartamento);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var apartamento = _context.Apartamentos.FirstOrDefault(t => t.Id == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            _context.Apartamentos.Remove(apartamento);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

