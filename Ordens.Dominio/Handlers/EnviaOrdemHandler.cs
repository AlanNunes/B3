using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using FluentValidation;
using MediatR;
using Ordens.Dominio.Commands.Requests;
using Ordens.Dominio.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ordens.Dominio.Handlers
{
    public class EnviaOrdemHandler : IRequestHandler<EnviaOrdemRequest, EnviaOrdemResponse>
    {
        private readonly IOrdemRepositorio _ordemRepositorio;
        private readonly IInvestidorRepositorio _investidorRepositorio;
        private readonly IValidator<EnviaOrdemRequest> _validadorRequisicao;
        private readonly IValidator<Ordem> _validadorOrdem;
        private readonly IMapper _mapper;

        public EnviaOrdemHandler(IOrdemRepositorio ordemRepositorio, IInvestidorRepositorio investidorRepositorio,
            IValidator<EnviaOrdemRequest> validadorRequisicao, IValidator<Ordem> validadorOrdem, IMapper mapper)
        {
            _ordemRepositorio = ordemRepositorio;
            _investidorRepositorio = investidorRepositorio;
            _validadorRequisicao = validadorRequisicao;
            _validadorOrdem = validadorOrdem;
            _mapper = mapper;
        }

        public async Task<EnviaOrdemResponse> Handle(EnviaOrdemRequest request, CancellationToken cancellationToken)
        {
            DateTime dataEnvio = DateTime.Now;
            var enviaOrdemResponse = _mapper.Map<EnviaOrdemRequest, EnviaOrdemResponse>(request);
            enviaOrdemResponse.DataEnvio = dataEnvio;
            var validacao = request.ValidaRequisicao(_validadorRequisicao);
            enviaOrdemResponse.AdicionaResultadoDaValidacao(validacao);
            Investidor investidor = await _investidorRepositorio.BuscaInvestidorPeloCPF(request.CPF);

            if (investidor == null)
                enviaOrdemResponse.AdicionaErro(nameof(request.CPF), request.CPF, "Não foi encontrado investidor com este CPF");

            if (!validacao.IsValid)
                return enviaOrdemResponse;

            var ordem = new Ordem(request.CodigoPapel, request.Valor, request.Quantidade, investidor, request.TipoOrdem)
            {
                DataEnvio = dataEnvio
            };
            var validacaoOrdem = _validadorOrdem.Validate(ordem);
            if (!validacaoOrdem.IsValid)
            {
                enviaOrdemResponse.AdicionaResultadoDaValidacao(validacaoOrdem);
                return enviaOrdemResponse;
            }
            await _ordemRepositorio.RegistraOrdem(ordem);
            enviaOrdemResponse.Id = ordem.Id;

            return enviaOrdemResponse;
        }
    }
}
