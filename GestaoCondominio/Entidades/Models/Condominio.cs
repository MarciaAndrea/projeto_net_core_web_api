using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class Condominio
    {
        public Condominio()
        {
            Moradores = new List<Morador>();
            ServicoCodominios = new List<ServicoCondominio>();
            ApartamentoCondominios = new List<ApartamentoCondominio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CNPJ { get; set; }
        public int NumAptos { get; set; }
        public int CidadeId { get; set; }
        public int EstadoId { get; set; }

        public virtual Cidade Cidades { get; set; }
        public virtual ICollection<Morador> Moradores { get; set; }
        public virtual Sindico Sindicos { get; set; }
        public virtual ICollection<ServicoCondominio> ServicoCodominios { get; set; }
        public virtual Estado Estados { get; set; }

        public virtual ICollection<ApartamentoCondominio> ApartamentoCondominios { get; set; }
    }
}
