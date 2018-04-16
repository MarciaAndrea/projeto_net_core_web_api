using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class Estado
    {
        public Estado()
        {
            Cidades = new List<Cidade>();
            Condominios = new List<Condominio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
        public virtual ICollection<Condominio> Condominios { get; set; }
    }
}
