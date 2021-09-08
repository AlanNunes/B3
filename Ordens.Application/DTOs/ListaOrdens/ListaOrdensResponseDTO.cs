using FluentValidation.Results;
using System.Collections.Generic;

namespace Ordens.Application.DTOs.ListaOrdens
{
    public class ListaOrdensResponseDTO
    {
        public IEnumerable<OrdemDTO> Ordens { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
