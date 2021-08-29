using Dominio.Entidades;
using MediatR;
using Ordens.Dominio.Commands.Requests;
using Ordens.Dominio.Commands.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordens.Dominio.Handlers
{
    public class EnviaOrdemHandler : IRequestHandler<EnviaOrdemRequest, EnviaOrdemResponse>
    {
        public Task<EnviaOrdemResponse> Handle(EnviaOrdemRequest request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return Task.FromCanceled<EnviaOrdemResponse>(cancellationToken);
            var ordem = new Ordem
            {
                CodigoPapel = request.CodigoPapel,
                Tipo = request.TipoOrdem,
                Valor = request.Valor,
                DataEnvio = DateTime.Now,
                Status = StatusOrdem.Enviada
            };

            var enviaOrdemResponse = new EnviaOrdemResponse
            {
                Id = new Random().Next(),
                CodigoPapel = ordem.CodigoPapel,
                Valor = ordem.Valor,
                Quantidade = request.Quantidade,
                DataEnvio = ordem.DataEnvio
            };

            return Task.FromResult(enviaOrdemResponse);
        }
    }
}
