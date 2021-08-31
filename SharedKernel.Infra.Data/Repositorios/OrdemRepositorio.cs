using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel.Infra.Data.Repositorios
{
    public class OrdemRepositorio : IOrdemRepositorio
    {
        private readonly B3Contexto _contexto;

        public OrdemRepositorio(B3Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task RegistraOrdem(Ordem ordem)
        {
            _contexto.Set<Ordem>();
            await _contexto.AddAsync(ordem);
        }

        public async Task RegistraOrdens(IEnumerable<Ordem> ordens)
        {
            _contexto.Set<Ordem>();
            await _contexto.AddRangeAsync(ordens);
        }
    }
}
