using FluentValidation;

using GymManager.Application.Commands.CreateGym;

namespace GymManager.Application.Validators;
public partial class CreateGymCommandValidator : AbstractValidator<CreateGymCommand>
{
    public CreateGymCommandValidator()
    {
        RuleFor(g => g.Title)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5)
            .MaximumLength(255);

        RuleFor(g => g.Latitude)
            .NotNull();

        RuleFor(g => g.Longitude)
            .NotNull();
    }

}
