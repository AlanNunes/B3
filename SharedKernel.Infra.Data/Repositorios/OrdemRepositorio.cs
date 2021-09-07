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

        public async Task<Ordem> BuscaOrdemPeloIdECPF(int id, string CPF)
        {
            return await _contexto.Ordens.FirstOrDefaultAsync(o => o.Id == id && o.Investidor.CPF == CPF);
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

        public async Task AlteraOrdem(Ordem ordem)
        {
            _contexto.Set<Ordem>();
            _contexto.Update(ordem);
            await _contexto.SaveChangesAsync();
        }
    }
}
