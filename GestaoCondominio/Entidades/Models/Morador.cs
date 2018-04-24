using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class Morador
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Fone { get; set; }
        public int CondominioId { get; set; }
        public int ApartamentoId { get; set; }

        public virtual Condominio Condominios { get; set; }
        public virtual ICollection<ContaMorador> ContaMoradores { get; set; }
        public virtual Sindico Sindico { get; set; }
        public virtual Apartamento Apartamentos { get; set; }

        public Morador()
        {
            ContaMoradores = new List<ContaMorador>();
        }
    }
}
