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

        public EnviaOrdemHandler(IOrdemRepositorio ordemRepositorio, IInvestidorRepositorio investidorRepositorio,
            IValidator<EnviaOrdemRequest> validadorRequisicao, IValidator<Ordem> validadorOrdem)
        {
            _ordemRepositorio = ordemRepositorio;
            _investidorRepositorio = investidorRepositorio;
            _validadorRequisicao = validadorRequisicao;
            _validadorOrdem = validadorOrdem;
        }

        public async Task<EnviaOrdemResponse> Handle(EnviaOrdemRequest request, CancellationToken cancellationToken)
        {
            DateTime dataEnvio = DateTime.Now;
            var enviaOrdemResponse = new EnviaOrdemResponse
            {
                CodigoPapel = request.CodigoPapel,
                Valor = request.Valor,
                Quantidade = request.Quantidade,
                CPF = request.CPF,
                DataEnvio = dataEnvio
            };
            var validacao = request.ValidaRequisicao(_validadorRequisicao);
            enviaOrdemResponse.AdicionaResultadoDaValidacao(validacao);
            Investidor investidor = await _investidorRepositorio.BuscaInvestidorPeloCPF(request.CPF);
            if (investidor == null)
                enviaOrdemResponse.AdicionaErro(nameof(request.CPF), request.CPF, "Não foi encontrado investidor com este CPF");
            if (!validacao.IsValid)
                return enviaOrdemResponse;
            var ordem = new Ordem
            {
                CodigoPapel = request.CodigoPapel,
                Tipo = request.TipoOrdem,
                Valor = request.Valor,
                InvestidorId = investidor.InvestidorId,
                Status = StatusOrdem.Enviada,
                DataEnvio = dataEnvio
            };

            await _ordemRepositorio.RegistraOrdem(ordem);
            return enviaOrdemResponse;
        }
    }
}
