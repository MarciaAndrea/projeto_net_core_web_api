using System;
using System.Collections.Generic;

namespace AppCondominio
{   
    public partial class ServicoCodominio
    {
        public int CondominioId { get; set; }
        public int ServicoId { get; set; }
    
        public virtual Condominio Condominio { get; set; }
        public virtual Servico Servico { get; set; }
    }
}
