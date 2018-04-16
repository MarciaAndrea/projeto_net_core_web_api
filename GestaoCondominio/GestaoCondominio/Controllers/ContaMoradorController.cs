using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;


namespace GestaoCondominio.Controllers
{
    [Route("api/[controller]")]
    public class ContaMoradorController : Controller
    {
        private readonly ApiContext _context;

        public ContaMoradorController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ContaMorador> GetAll()
        {
            return _context.ContaMoradores.ToList();
        }

        [HttpGet("{id}", Name = "GetContaMorador")]
        public IActionResult GetById(int id)
        {
            var item = _context.ContaMoradores.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]ContaMorador item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.ContaMoradores.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetContaMorador", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ContaMorador item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var contaMorador = _context.ContaMoradores.FirstOrDefault(t => t.Id == id);
            if (contaMorador == null)
            {
                return NotFound();
            }

            contaMorador.Valor = item.Valor;
            contaMorador.DataVencimento = item.DataVencimento;
            contaMorador.DataPagamento = item.DataPagamento;
            contaMorador.Juros = item.Juros;
            contaMorador.ValorTotal = item.ValorTotal;


            _context.ContaMoradores.Update(contaMorador);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contaMorador = _context.ContaMoradores.FirstOrDefault(t => t.Id == id);
            if (contaMorador == null)
            {
                return NotFound();
            }

            _context.ContaMoradores.Remove(contaMorador);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
