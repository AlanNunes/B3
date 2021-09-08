using Dominio.Entidades;
using System.Collections.Generic;

namespace Ordens.Dominio.Commands.Responses.ListaOrdens
{
    public class ListaOrdensResponse : Response
    {
        public IEnumerable<Ordem> Ordens { get; set; }
    }
}
