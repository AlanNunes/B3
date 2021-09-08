using AutoMapper;
using Dominio.Interfaces.Repositorios;
using FluentValidation;
using MediatR;
using Ordens.Dominio.Commands.Requests;
using Ordens.Dominio.Commands.Responses.ListaOrdens;
using System.Threading;
using System.Threading.Tasks;

namespace Ordens.Dominio.Handlers
{
    public class ListaOrdensHandler : IRequestHandler<ListaOrdensRequest, ListaOrdensResponse>
    {
        private readonly IOrdemRepositorio _ordemRepositorio;
        private readonly IValidator<ListaOrdensRequest> _validadorRequisicao;
        private readonly IInvestidorRepositorio _investidorRepositorio;
        private readonly IMapper _mapper;

        public ListaOrdensHandler(IOrdemRepositorio ordemRepositorio, IValidator<ListaOrdensRequest> validadorRequisicao,
            IInvestidorRepositorio investidorRepositorio, IMapper mapper)
        {
            _ordemRepositorio = ordemRepositorio;
            _validadorRequisicao = validadorRequisicao;
            _investidorRepositorio = investidorRepositorio;
            _mapper = mapper;
        }
        public async Task<ListaOrdensResponse> Handle(ListaOrdensRequest request, CancellationToken cancellationToken)
        {
            var validacao = _validadorRequisicao.Validate(request);
            var response = new ListaOrdensResponse();
            if (!validacao.IsValid)
                return response;
            response.AdicionaResultadoDaValidacao(validacao);
            var investidor = await _investidorRepositorio.BuscaInvestidorPeloCPF(request.CPF);
            if (investidor == null)
            {
                response.AdicionaErro(nameof(request.CPF), request.CPF, "Não foi encontrado investidor com esse CPF");
                return response;
            }
            var ordens = await _ordemRepositorio.BuscaOrdensPorInvestidor(investidor.InvestidorId);
            response.Ordens = ordens;

            return response;
        }
    }
}
