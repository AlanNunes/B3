using MediatR;
using Ordens.Dominio.Commands.Responses.ListaOrdens;

namespace Ordens.Dominio.Commands.Requests
{
    public class ListaOrdensRequest : IRequest<ListaOrdensResponse>
    {
        public string CPF { get; set; }
        public Intervalo Intervalo { get; set; }
    }
}
