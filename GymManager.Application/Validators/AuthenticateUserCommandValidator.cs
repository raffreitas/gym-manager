using FluentValidation;

using GymManager.Application.Commands.AuthenticateUser;

namespace GymManager.Application.Validators;
public partial class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
{
    public AuthenticateUserCommandValidator()
    {
        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Deve ser informado um e-mail");

        RuleFor(u => u.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("Deve ser informado uma senha");
    }
}
