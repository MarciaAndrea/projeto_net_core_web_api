using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class Servico
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal Rateio { get; set; }

        public virtual ICollection<ServicoCondominio> ServicoCodominios { get; set; }

        public Servico()
        {
            ServicoCodominios = new List<ServicoCondominio>();
        }
    }
}
