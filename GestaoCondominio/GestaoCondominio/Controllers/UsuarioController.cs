using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;

namespace GestaoCondominio.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ApiContext _context;

        public UsuarioController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(int id)
        {
            var item = _context.Usuarios.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Usuarios.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetUsuario", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Usuario item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var usuario = _context.Usuarios.FirstOrDefault(t => t.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Login = item.Login;
            usuario.Senha = item.Senha;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(t => t.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
