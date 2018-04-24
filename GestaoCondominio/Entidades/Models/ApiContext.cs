using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Entidades.Models
{
    public class ApiContext : DbContext
    {

        public DbSet<ServicoCondominio> ServicoCondominios { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<ContaMorador> ContaMoradores { get; set; }
        public DbSet<Morador> Moradores { get; set; }
        public DbSet<ApartamentoCondominio> ApartamentoCondominios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sindico> Sindicos { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public ApiContext()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Obtém as configurações especificadas em appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Define a base de dados a ser usada

            var cnn = config.GetConnectionString("GestaoCondominio");
            //optionsBuilder.UseInMemoryDatabase("GestaoCondominio"); 
            optionsBuilder.UseSqlite(cnn);
            //optionsBuilder.UseSqlServer(cnn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento Many-to-Many (chaves compostas)
            modelBuilder.Entity<ApartamentoCondominio>()
                .HasKey(pt => new { ApartamentoId = pt.ApartamentoId, TagId = pt.CondominioId });
            modelBuilder.Entity<ServicoCondominio>()
                .HasKey(pt => new { ApartamentoId = pt.ServicoId, TagId = pt.CondominioId });

            // Chaves Únicas
            modelBuilder.Entity<Sindico>().HasIndex(c => c.UsuarioId).IsUnique(true);


            // Solução OnDelete
            //modelBuilder.Entity<ApartamentoCondominio>()
            //    .HasOne(p => p.Apartamento)
            //    .WithMany(m => m.ApartamentoCondominio)
            //    .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
