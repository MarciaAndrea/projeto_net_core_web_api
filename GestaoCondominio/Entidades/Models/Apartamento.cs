using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class Apartamento
    {
        public int Id { get; set; }
        public string Apto { get; set; }
        public string Situacao { get; set; }


        public virtual ICollection<ApartamentoCondominio> ApartamentoCondominios { get; set; }
        public virtual ICollection<Morador> Moradores { get; set; }

        public Apartamento()
        {
            ApartamentoCondominios = new List<ApartamentoCondominio>();
            Moradores = new List<Morador>();
        }
    }
}
