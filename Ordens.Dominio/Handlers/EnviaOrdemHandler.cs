using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
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

        public EnviaOrdemHandler(IOrdemRepositorio ordemRepositorio, IInvestidorRepositorio investidorRepositorio)
        {
            _ordemRepositorio = ordemRepositorio;
            _investidorRepositorio = investidorRepositorio;
        }

        public async Task<EnviaOrdemResponse> Handle(EnviaOrdemRequest request, CancellationToken cancellationToken)
        {
            Investidor investidor = await _investidorRepositorio.BuscaInvestidorPeloCPF(request.CPF);
            DateTime dataEnvio = DateTime.Now;
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

            var enviaOrdemResponse = new EnviaOrdemResponse
            {
                Id = ordem.Id,
                CodigoPapel = request.CodigoPapel,
                Valor = request.Valor,
                Quantidade = request.Quantidade,
                CPF = request.CPF,
                DataEnvio = dataEnvio
            };
            return enviaOrdemResponse;
        }
    }
}
