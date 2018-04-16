using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Sindicos = new List<Sindico>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Sindico> Sindicos { get; set; }
    }
}
