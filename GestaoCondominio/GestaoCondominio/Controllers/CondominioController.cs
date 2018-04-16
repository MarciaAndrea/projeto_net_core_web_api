using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;


namespace GestaoCondominio.Controllers
{
    [Route("api/[controller]")]
    public class CondominioController : Controller
    {
        private readonly ApiContext _context;

        public CondominioController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Condominio> GetAll()
        {
            return _context.Condominios.ToList();
        }

        [HttpGet("{id}", Name = "GetCondominio")]
        public IActionResult GetById(int id)
        {
            var item = _context.Condominios.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Condominio item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Condominios.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCondominio", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Condominio item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var condominio = _context.Condominios.FirstOrDefault(t => t.Id == id);
            if (condominio == null)
            {
                return NotFound();
            }

            condominio.Nome = item.Nome;
            condominio.Endereco = item.Endereco;
            condominio.Bairro = item.Bairro;
            condominio.CNPJ = item.CNPJ;
            condominio.NumAptos = item.NumAptos;

            _context.Condominios.Update(condominio);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var condominio = _context.Condominios.FirstOrDefault(t => t.Id == id);
            if (condominio == null)
            {
                return NotFound();
            }

            _context.Condominios.Remove(condominio);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
