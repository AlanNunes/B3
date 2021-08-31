using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorios
{
    public interface IOrdemRepositorio
    {
        Task RegistraOrdem(Ordem ordem);
        Task RegistraOrdens(IEnumerable<Ordem> ordens);
    }
}
