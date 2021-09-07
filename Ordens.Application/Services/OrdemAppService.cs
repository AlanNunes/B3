using AutoMapper;
using MediatR;
using Ordens.Application.DTOs;
using Ordens.Application.Interfaces;
using Ordens.Dominio.Commands.Requests;
using System.Threading.Tasks;

namespace Ordens.Application.Services
{
    public class OrdemAppService : IOrdemAppService
    {
        private readonly IMediator _handler;
        private readonly IMapper _mapper;

        public OrdemAppService(IMediator handler, IMapper mapper)
        {
            _handler = handler;
            _mapper = mapper;
        }

        public async Task<CancelaOrdemResponseDTO> CancelaOrdem(CancelaOrdemRequestDTO ordem)
        {
            var ordemRequest = _mapper.Map<CancelaOrdemRequest>(ordem);
            var response = await _handler.Send(ordemRequest);
            var responseDTO = _mapper.Map<CancelaOrdemResponseDTO>(response);
            return responseDTO;
        }

        public async Task<EnviaOrdemResponseDTO> EnviaOrdem(EnviaOrdemRequestDTO ordem)
        {
            var ordemRequest = _mapper.Map<EnviaOrdemRequest>(ordem);
            var response = await _handler.Send(ordemRequest);
            var responseDTO = _mapper.Map<EnviaOrdemResponseDTO>(response);
            return responseDTO;
        }
    }
}
