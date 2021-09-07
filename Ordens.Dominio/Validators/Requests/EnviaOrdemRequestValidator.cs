using FluentValidation;
using Ordens.Dominio.Commands.Requests;

namespace Ordens.Dominio.Validators.Requests
{
    public class EnviaOrdemRequestValidator : AbstractValidator<EnviaOrdemRequest>
    {
        public EnviaOrdemRequestValidator()
        {
            RuleFor(x => x.CPF)
                .Matches(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")
                .WithMessage("CPF informado inválido");
            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade de papel tem que superior a 0");
            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .WithMessage("O valor de uma ordem deve ser superior a 0");
            RuleFor(x => x.CodigoPapel)
                .NotEmpty()
                .WithMessage("Você precisa informar o papel");
        }
    }
}
