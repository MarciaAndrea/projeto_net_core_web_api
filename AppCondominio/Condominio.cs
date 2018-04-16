using System;
using System.Collections.Generic;

namespace AppCondominio
{
    
    public partial class Condominio
    {
        public Condominio()
        {
            this.Morador = new HashSet<Morador>();
            this.ServicoCodominio = new HashSet<ServicoCodominio>();
            this.ApartamentoCondominio = new HashSet<ApartamentoCondominio>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CNPJ { get; set; }
        public int NumAptos { get; set; }
        public int CidadeId { get; set; }
        public int EstadoId { get; set; }
    
        public virtual Cidade Cidade1 { get; set; }
        public virtual ICollection<Morador> Morador { get; set; }
        public virtual Sindico Sindico { get; set; }
        public virtual ICollection<ServicoCodominio> ServicoCodominio { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<ApartamentoCondominio> ApartamentoCondominio { get; set; }
    }
}
