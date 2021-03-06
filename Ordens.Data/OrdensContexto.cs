using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Ordens.Data
{
    public class OrdensContexto : DbContext
    {
        public DbSet<Ordem> Ordens { get; set; }
        public DbSet<Papel> Papel { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public OrdensContexto(DbContextOptions<OrdensContexto> options) : base(options) { }
    }
}
