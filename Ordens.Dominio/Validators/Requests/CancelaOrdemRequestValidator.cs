using FluentValidation;
using Ordens.Dominio.Commands.Requests;

namespace Ordens.Dominio.Validators.Requests
{
    public class CancelaOrdemRequestValidator : AbstractValidator<CancelaOrdemRequest>
    {
        public CancelaOrdemRequestValidator()
        {
            RuleFor(co => co.Id)
                .NotEmpty()
                .WithMessage("Você precisa passar o código da ordem");
            RuleFor(co => co.CPF)
                .Matches(@"^[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}$")
                .WithMessage("CPF inválido");
        }
    }
}
