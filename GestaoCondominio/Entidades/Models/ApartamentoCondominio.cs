using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class ApartamentoCondominio
    {
        [NotMapped]
        public int Id { get; set; }
        
        public int ApartamentoId { get; set; }
        public int CondominioId { get; set; }

        public virtual Apartamento Apartamentos { get; set; }
        public virtual Condominio Condominios { get; set; }
    }
}
