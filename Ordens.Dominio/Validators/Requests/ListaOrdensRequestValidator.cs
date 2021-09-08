using FluentValidation;
using Ordens.Dominio.Commands.Requests;
using Ordens.Dominio.Commands.Responses.ListaOrdens;

namespace Ordens.Dominio.Validators.Requests
{
    public class ListaOrdensRequestValidator : AbstractValidator<ListaOrdensRequest>
    {
        public ListaOrdensRequestValidator()
        {
            RuleFor(lst => lst.CPF)
                .Matches(@"^[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}$")
                .WithMessage("CPF inválido");
            RuleFor(lst => lst.Intervalo)
                .Must(IntervaloValido)
                .WithMessage("Intervalo de datas inválido");
        }

        public static bool IntervaloValido(Intervalo intervalo)
        {
            return intervalo.Inicio < intervalo.Fim;
        }
    }
}
