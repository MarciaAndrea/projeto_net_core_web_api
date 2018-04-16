using System;
using System.Collections.Generic;

namespace AppCondominio
{ 
    public partial class Servico
    {
        public Servico()
        {
            this.ServicoCodominio = new HashSet<ServicoCodominio>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal Rateio { get; set; }

        public virtual ICollection<ServicoCodominio> ServicoCodominio { get; set; }
    }
}
