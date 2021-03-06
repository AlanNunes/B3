// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharedKernel.Infra.Data;

namespace SharedKernel.Infra.Data.Migrations
{
    [DbContext(typeof(B3Contexto))]
    partial class B3ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Entidades.DepositoAcaoInvestidor", b =>
                {
                    b.Property<int>("DepositoAcaoInvestidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvestidorId")
                        .HasColumnType("int");

                    b.Property<int>("PapelId")
                        .HasColumnType("int");

                    b.HasKey("DepositoAcaoInvestidorId");

                    b.HasIndex("InvestidorId");

                    b.HasIndex("PapelId");

                    b.ToTable("DepositoAcaoInvestidor");
                });

            modelBuilder.Entity("Dominio.Entidades.Empresa", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassificacaoSetorial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpresaId");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Dominio.Entidades.Investidor", b =>
                {
                    b.Property<int>("InvestidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimeiroNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UltimoNome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InvestidorId");

                    b.ToTable("Investidor");
                });

            modelBuilder.Entity("Dominio.Entidades.Ordem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoPapel")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvestidorId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("InvestidorId");

                    b.ToTable("Ordens");
                });

            modelBuilder.Entity("Dominio.Entidades.Papel", b =>
                {
                    b.Property<int>("PapelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.HasKey("PapelId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Papel");
                });

            modelBuilder.Entity("Dominio.Entidades.DepositoAcaoInvestidor", b =>
                {
                    b.HasOne("Dominio.Entidades.Investidor", "Investidor")
                        .WithMany("Acoes")
                        .HasForeignKey("InvestidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Papel", "Papel")
                        .WithMany()
                        .HasForeignKey("PapelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Investidor");

                    b.Navigation("Papel");
                });

            modelBuilder.Entity("Dominio.Entidades.Ordem", b =>
                {
                    b.HasOne("Dominio.Entidades.Investidor", "Investidor")
                        .WithMany("Ordens")
                        .HasForeignKey("InvestidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Investidor");
                });

            modelBuilder.Entity("Dominio.Entidades.Papel", b =>
                {
                    b.HasOne("Dominio.Entidades.Empresa", "Empresa")
                        .WithMany("Papeis")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Dominio.Entidades.Empresa", b =>
                {
                    b.Navigation("Papeis");
                });

            modelBuilder.Entity("Dominio.Entidades.Investidor", b =>
                {
                    b.Navigation("Acoes");

                    b.Navigation("Ordens");
                });
#pragma warning restore 612, 618
        }
    }
}
