using System;
using System.Collections.Generic;

namespace AppCondominio
{ 
    public partial class Estado
    {
        public Estado()
        {
            this.Cidade = new HashSet<Cidade>();
            this.Condominio = new HashSet<Condominio>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public virtual ICollection<Cidade> Cidade { get; set; }
        public virtual ICollection<Condominio> Condominio { get; set; }
    }
}
