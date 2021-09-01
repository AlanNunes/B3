using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SharedKernel.Infra.Data.Mapeamentos
{
    public class OrdemMapeamento : IEntityTypeConfiguration<Ordem>
    {
        public void Configure(EntityTypeBuilder<Ordem> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.CodigoPapel).HasMaxLength(10);
            builder.HasOne(o => o.Investidor).WithMany(inv => inv.Ordens).HasForeignKey(o => o.InvestidorId);
        }
    }
}
