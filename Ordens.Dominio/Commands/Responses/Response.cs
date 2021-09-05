using FluentValidation.Results;

namespace Ordens.Dominio.Commands.Responses
{
    public class Response
    {
        public ValidationResult ValidationResult { get; set; }
        public ValidationResult AdicionaResultadoDaValidacao(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
            return ValidationResult;
        }

        public void AdicionaErro(string propriedade, string valor, string mensagem)
        {
            ValidationFailure erro = new ValidationFailure(propriedade, mensagem, valor);
            ValidationResult.Errors.Add(erro);
        }
    }
}
