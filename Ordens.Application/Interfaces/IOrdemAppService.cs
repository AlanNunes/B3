using Ordens.Application.DTOs;
using System.Threading.Tasks;

namespace Ordens.Application.Interfaces
{
    public interface IOrdemAppService
    {
        Task<EnviaOrdemResponseDTO> EnviaOrdem(EnviaOrdemRequestDTO ordem);
        Task<CancelaOrdemResponseDTO> CancelaOrdem(CancelaOrdemRequestDTO ordem);
    }
}
