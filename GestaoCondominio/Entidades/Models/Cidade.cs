using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class Cidade
    {
        public Cidade()
        {
            Condominios = new List<Condominio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }

        public virtual Estado Estados { get; set; }
        public virtual ICollection<Condominio> Condominios { get; set; }
    }
}
