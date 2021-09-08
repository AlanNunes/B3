using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorios
{
    public interface IOrdemRepositorio
    {
        Task RegistraOrdem(Ordem ordem);
        Task AlteraOrdem(Ordem ordem);
        Task<IEnumerable<Ordem>> BuscaOrdensPorInvestidor(int investidorId);
        Task<Ordem> BuscaUltimaOrdemEnviadaPorInvestidor(int investidorId);
        Task<Ordem> BuscaOrdemPeloIdECPF(int id, string CPF);
    }
}
