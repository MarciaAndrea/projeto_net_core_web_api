using System;
using System.Collections.Generic;

namespace AppCondominio
{
 
    public partial class Apartamento
    {
        public Apartamento()
        {
            this.ApartamentoCondominio = new HashSet<ApartamentoCondominio>();
            this.Morador = new HashSet<Morador>();
        }
    
        public int Id { get; set; }
        public string Apto { get; set; }
        public string Situacao { get; set; }

        public virtual ICollection<ApartamentoCondominio> ApartamentoCondominio { get; set; }
        public virtual ICollection<Morador> Morador { get; set; }
    }
}
