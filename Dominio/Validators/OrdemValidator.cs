using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validators
{
    public class OrdemValidator : AbstractValidator<Ordem>
    {
        public OrdemValidator()
        {
            RuleFor(o => o.Quantidade)
                .GreaterThan(0);
            RuleFor(o => o.Valor)
                .GreaterThan(0);
            RuleFor(o => o.CodigoPapel)
                .NotEmpty();
        }
    }
}
