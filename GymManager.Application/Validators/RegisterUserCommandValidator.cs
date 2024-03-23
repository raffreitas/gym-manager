using System.Text.RegularExpressions;

using FluentValidation;

using GymManager.Application.Commands.RegisterUser;

namespace GymManager.Application.Validators;
public partial class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("E-mail inválido");

        RuleFor(u => u.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nome é obrigatório");

        RuleFor(u => u.Password)
            .Must(ValidPassword)
            .WithMessage("A senha deve conter pelo menos 8 caracteres, letras, números e caracteres especiais");
    }

    private bool ValidPassword(string password)
    {
        var regex = PassordValidRegex();
        return regex.IsMatch(password);
    }

    [GeneratedRegex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$")]
    private static partial Regex PassordValidRegex();
}
