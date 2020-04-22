using FluentValidation;
using PasswordValidatorAPI.Models;

namespace PasswordValidatorAPI.Validators
{
    public class PasswordValidator : AbstractValidator<RequestPassword>
    {
        public PasswordValidator()
        {
            RuleFor(x => x.Password).Password();
        }
    }

    public static class RuleBuilderExtensions
    {
        public static void Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage("Senha não pode ser vazio")
                .MinimumLength(9).WithMessage("Senha deve conter Nove ou mais caracteres")
                .Matches("[A-Z]").WithMessage("Senha deve conter ao menos 1 letra maiúscula")
                .Matches("[a-z]").WithMessage("Senha deve conter ao menos 1 letra minúscula")
                .Matches("[0-9]").WithMessage("Senha deve conter ao menos 1 dígito")
                .Matches("[^a-zA-Z0-9]").WithMessage("Senha deve conter ao menos 1 caractere especial");
        }
    }
}