using Dominio.Entidades;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Ordens.Dominio.Commands.Responses;

namespace Ordens.Dominio.Commands.Requests
{
    public class EnviaOrdemRequest : IRequest<EnviaOrdemResponse>
    {
        public string CodigoPapel { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public string CPF { get; set; }
        public TipoOrdem TipoOrdem { get; set; }
    }
}
