using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class ApartamentoCondominio
    {
        public int Id { get; set; }
        public int ApartamentoId { get; set; }
        public int CondominioId { get; set; }

        public virtual Apartamento Apartamentos { get; set; }
        public virtual Condominio Condominios { get; set; }
    }
}
