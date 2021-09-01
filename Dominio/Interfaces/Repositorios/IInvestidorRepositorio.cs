using Dominio.Entidades;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorios
{
    public interface IInvestidorRepositorio
    {
        Task<Investidor> BuscaInvestidorPeloCPF(string CPF);
    }
}
