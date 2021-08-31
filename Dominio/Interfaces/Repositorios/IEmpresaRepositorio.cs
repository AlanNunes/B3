using Dominio.Entidades;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorios
{
    public interface IEmpresaRepositorio
    {
        Task CadastraEmpresa(Empresa empresa);
        Task AtualizaEmpresa(Empresa empresa);
        Task ExcluiEmpresa(Empresa empresa);
    }
}
