using MediatR;
using Ordens.Dominio.Commands.Requests;
using Ordens.Dominio.Commands.Responses;
using AutoMapper;
using Dominio.Interfaces.Repositorios;
using FluentValidation;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Entidades;

namespace Ordens.Dominio.Handlers
{
    public class CancelaOrdemHandler : IRequestHandler<CancelaOrdemRequest, CancelaOrdemResponse>
    {
        private readonly IOrdemRepositorio _ordemRepositorio;
        private readonly IValidator<CancelaOrdemRequest> _validadorRequisicao;
        private readonly IMapper _mapper;

        public CancelaOrdemHandler(IOrdemRepositorio ordemRepositorio, IValidator<CancelaOrdemRequest> validadorRequisicao, IMapper mapper)
        {
            _ordemRepositorio = ordemRepositorio;
            _validadorRequisicao = validadorRequisicao;
            _mapper = mapper;
        }

        public async Task<CancelaOrdemResponse> Handle(CancelaOrdemRequest request, CancellationToken cancellationToken)
        {
            var validacao = _validadorRequisicao.Validate(request);
            var response = new CancelaOrdemResponse();
            response.AdicionaResultadoDaValidacao(validacao);
            if (!validacao.IsValid)
                return response;
            var ordem = await _ordemRepositorio.BuscaOrdemPeloIdECPF(request.Id, request.CPF);
            if (ordem == null)
            {
                response.AdicionaErro(nameof(request.CPF), request.CPF, "Não foi encontrada uma ordem para este CPF");
                return response;
            }
            ordem.Status = StatusOrdem.Cancelada;
            await _ordemRepositorio.AlteraOrdem(ordem);
            return response;
        }
    }
}
