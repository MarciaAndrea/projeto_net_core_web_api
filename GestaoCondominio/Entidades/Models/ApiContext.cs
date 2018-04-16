using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base()
        {
        }

        public  DbSet<ServicoCondominio> ServicoCondominios { get; set; }
        public  DbSet<Cidade> Cidades { get; set; }
        public  DbSet<Apartamento> Apartamentos { get; set; }
        public  DbSet<Estado> Estados { get; set; }
        public  DbSet<Condominio> Condominios { get; set; }
        public  DbSet<Servico> Servicos { get; set; }
        public  DbSet<ContaMorador> ContaMoradores { get; set; }
        public  DbSet<Morador> Moradores { get; set; }
        public  DbSet<ApartamentoCondominio> ApartamentoCondominios { get; set; }
        public  DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sindico> Sindicos { get; set; }
    }
}
