using FluentValidation;
using MediatR;
using Ordens.Dominio.Commands.Responses;

namespace Ordens.Dominio.Commands.Requests
{
    public class CancelaOrdemRequest : IRequest<CancelaOrdemResponse>
    {
        public int Id { get; set; }
        public string CPF { get; set; }
    }
}
