﻿using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SharedKernel.Infra.Data
{
    public class B3Contexto : DbContext
    {
        public DbSet<Ordem> Ordens { get; set; }
        public DbSet<Papel> Papel { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public B3Contexto(DbContextOptions<B3Contexto> options) : base(options) { }
    }
}
