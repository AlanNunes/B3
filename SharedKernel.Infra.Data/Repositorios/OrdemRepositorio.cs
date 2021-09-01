using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Ordem> BuscaUltimaOrdemEnviadaPorInvestidor(int investidorId)
        {
            return await _contexto.Ordens.LastOrDefaultAsync(o => o.InvestidorId == investidorId);
        }

        public async Task RegistraOrdem(Ordem ordem)
        {
            _contexto.Set<Ordem>();
            await _contexto.AddAsync(ordem);
            await _contexto.SaveChangesAsync();
        }
    }
}
