using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class ContaMorador
    {
        public int Id { get; set; }
        public int MoradorId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Juros { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual Morador Moradores { get; set; }
    }
}
