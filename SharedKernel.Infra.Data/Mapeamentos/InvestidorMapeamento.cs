using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SharedKernel.Infra.Data.Mapeamentos
{
    public class InvestidorMapeamento : IEntityTypeConfiguration<Investidor>
    {
        public void Configure(EntityTypeBuilder<Investidor> builder)
        {
            builder.HasKey(inv => inv.InvestidorId);
            builder.Property(inv => inv.InvestidorId).ValueGeneratedOnAdd();
        }
    }
}
