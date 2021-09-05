using FluentValidation;
using Ordens.Dominio.Commands.Requests;

namespace Ordens.Dominio.Validators.Requests
{
    public class EnviaOrdemRequestValidator : AbstractValidator<EnviaOrdemRequest>
    {
        public EnviaOrdemRequestValidator()
        {
            RuleFor(x => x.CPF)
                .Matches(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})");
            RuleFor(x => x.Quantidade)
                .GreaterThan(0);
            RuleFor(x => x.Valor)
                .GreaterThan(0);
            RuleFor(x => x.CodigoPapel)
                .NotEmpty();
        }
    }
}
