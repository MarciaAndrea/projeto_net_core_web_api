using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class Sindico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Condominio Condominios { get; set; }
        public virtual Morador Moradores { get; set; }
    }
}
