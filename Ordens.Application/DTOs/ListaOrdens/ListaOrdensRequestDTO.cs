using System;
namespace Ordens.Application.DTOs.ListaOrdens
{
    public class ListaOrdensRequestDTO
    {
        public string CPF { get; set; }
        public DateTime DataInicioIntervalo { get; set; }
        public DateTime DataFimIntervalo { get; set; }
    }
}
