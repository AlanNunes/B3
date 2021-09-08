using Ordens.Application.DTOs;
using Ordens.Application.DTOs.ListaOrdens;
using System.Threading.Tasks;

namespace Ordens.Application.Interfaces
{
    public interface IOrdemAppService
    {
        Task<EnviaOrdemResponseDTO> EnviaOrdem(EnviaOrdemRequestDTO ordem);
        Task<CancelaOrdemResponseDTO> CancelaOrdem(CancelaOrdemRequestDTO ordem);
        Task<ListaOrdensResponseDTO> ListaOrdens(ListaOrdensRequestDTO request);
    }
}
