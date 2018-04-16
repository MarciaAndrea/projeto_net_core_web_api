using System;
using System.Collections.Generic;

namespace AppCondominio
{  
    public partial class Morador
    {
        public Morador()
        {
            this.ContaMorador = new HashSet<ContaMorador>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Fone { get; set; }
        public int CondominioId { get; set; }
        public int ApartamentoId { get; set; }
    
        public virtual Condominio Condominio { get; set; }
        public virtual ICollection<ContaMorador> ContaMorador { get; set; }
        public virtual Sindico Sindico { get; set; }
        public virtual Apartamento Apartamento { get; set; }
    }
}
