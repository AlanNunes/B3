using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infra.Data.Mapeamentos;

namespace SharedKernel.Infra.Data
{
    public class B3Contexto : DbContext
    {
        public DbSet<Ordem> Ordens { get; set; }
        public DbSet<Papel> Papel { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Investidor> Investidor { get; set; }
        public B3Contexto(DbContextOptions<B3Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrdemMapeamento());
        }
    }
}
