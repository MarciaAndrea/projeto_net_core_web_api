using System;
using System.Collections.Generic;

namespace AppCondominio
{   
    public partial class Cidade
    {
        public Cidade()
        {
            this.Condominio = new HashSet<Condominio>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual ICollection<Condominio> Condominio { get; set; }
    }
}
