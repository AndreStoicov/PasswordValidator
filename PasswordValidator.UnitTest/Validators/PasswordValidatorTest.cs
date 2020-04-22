using FluentValidation.TestHelper;
using PasswordValidatorAPI.Controller;
using Xunit;

namespace PasswordValidator.UnitTest.Validators
{
    public class PasswordControllerTest
    {
        private static PasswordController GetService() => new PasswordController();
        private PasswordValidatorAPI.Validators.PasswordValidator _validator;

        public void Setup()
        {
            _validator = new PasswordValidatorAPI.Validators.PasswordValidator();
        }

        [Fact(DisplayName = "Deveria aceitar uma senha válida")]
        public void Should_AceptValidPassword()
        {
            Setup();

            _validator.ShouldNotHaveValidationErrorFor(x => x.Password, "Teste@12345678");
        }

        [Fact(DisplayName = "Deveria validar uma senha em branco")]
        public void Should_ValidateEmptyPassword()
        {
            Setup();

            _validator.ShouldHaveValidationErrorFor(x => x.Password, string.Empty)
                .WithErrorMessage("Senha não pode ser vazio");
        }

        [Fact(DisplayName = "Deveria validar uma senha null")]
        public void Should_ValidateNullPassword()
        {
            Setup();

            string password = null;

            _validator.ShouldHaveValidationErrorFor(x => x.Password, password)
                .WithErrorMessage("Senha não pode ser vazio");
        }

        [Fact(DisplayName = "Deveria validar uma senha menor que 9 caracteres")]
        public void Should_ValidateLenghtPassword()
        {
            Setup();

            _validator.ShouldHaveValidationErrorFor(x => x.Password, "Teste@1")
                .WithErrorMessage("Senha deve conter Nove ou mais caracteres");
        }

        [Fact(DisplayName = "Deveria validar uma senha sem letras maiúscula")]
        public void Should_ValidateUpcasePassword()
        {
            Setup();

            _validator.ShouldHaveValidationErrorFor(x => x.Password, "teste@123")
                .WithErrorMessage("Senha deve conter ao menos 1 letra maiúscula");
        }

        [Fact(DisplayName = "Deveria validar uma senha sem letras minúscula")]
        public void Should_ValidateLowercasePassword()
        {
            Setup();

            _validator.ShouldHaveValidationErrorFor(x => x.Password, "TESTE@123")
                .WithErrorMessage("Senha deve conter ao menos 1 letra minúscula");
        }

        [Fact(DisplayName = "Deveria validar uma senha sem dígito")]
        public void Should_ValidateDigitPassword()
        {
            Setup();

            _validator.ShouldHaveValidationErrorFor(x => x.Password, "TESTE@abc")
                .WithErrorMessage("Senha deve conter ao menos 1 dígito");
        }

        [Fact(DisplayName = "Deveria validar uma senha sem caractere especial")]
        public void Should_ValidateSpecialCharacterePassword()
        {
            Setup();

            _validator.ShouldHaveValidationErrorFor(x => x.Password, "TESTEaabc")
                .WithErrorMessage("Senha deve conter ao menos 1 caractere especial");
        }
    }
}